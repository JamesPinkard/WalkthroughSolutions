using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace AutoLotConnectedLayer
{
    public class InventoryDAL
    {
        // This member will be used by all methods.
        private SqlConnection sqlCN = null;

        public void OpenConnection(string connectionString)
        {
            sqlCN = new SqlConnection();
            sqlCN.ConnectionString = connectionString;
            sqlCN.Open();
        }

        public void CloseConnection()
        {
            sqlCN.Close();
        }

        public void InsertAuto(int id, string color, string make, string petName)
        {
            // Note the "placeholders" in the SQL query.
            string sql = string.Format("Insert Into Inventory(CarID, Make, Color, PetName)" +
                " Values(@CarID, @Make, @Color, @PetName)");

            // This command will have internal parameters.
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCN))
            {
                // Fill params collection.
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@CarID";
                param.Value = id;
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Make";
                param.Value = make;
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Color";
                param.Value = make;
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@PetName";
                param.Value = petName;
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();                
            }
        }

        public void InsertAuto(NewCar car)
        {
            // Format and execute SQL statement.
            string sql = string.Format("Insert Into Inventory" +
                "(CarID, Make, Color, PetName) Values" +
                "('{0}', '{1}', '{2}', '{3}')", car.CarID, car.Make, car.Color, car.PetName);

            // Execute using our connection.
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCN))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int id)
        {
            string sql = string.Format("Delete from Inventory where CarID = '{0}'", id);

            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCN))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
        }

        public void UpdateCarPetName(int id, string newPetName)
        {
            // Get ID of car to modify and new pet name.
            string sql = string.Format("Uptate Inventory Set PetName = '{0}' Where CarID = '{1}'",
                newPetName, id);

            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCN))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public List<NewCar> GetAllInventoryAsList()
        {
            // This will hold the records.
            List<NewCar> inv = new List<NewCar>();

            // Prep command object.
            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCN))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    inv.Add(new NewCar
                        {
                            CarID = (int)dr["CarID"],
                            Color = (string)dr["Color"],
                            Make = (string)dr["Make"],
                            PetName = (string)dr["PetName"]
                        });
                }
                dr.Close();
            }
            return inv;
        }

        public DataTable GetAllInventoryAsTable()
        {
            // This will hold the records.
            DataTable inv = new DataTable();
            
            // Prep command object.
            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCN))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                // Fill the DataTable with data from the reader and clean up.
                inv.Load(dr);
                dr.Close();
            }
            return inv;            
        }

        public string LookUpPetName(int carID)
        {
            string carPetName = string.Empty;

            // Establish name of stored proc.
            using (SqlCommand cmd = new SqlCommand("GetPetName", this.sqlCN))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Input param.
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@carID";
                param.SqlDbType = SqlDbType.Int;
                param.Value = carID;

                // The default direction is in fact Input, but to be clear:
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                // Output param.
                param = new SqlParameter();
                param.ParameterName = "@petName";
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                // Execute the stored proc.
                cmd.ExecuteNonQuery();

                // Return output param.
                carPetName = (string)cmd.Parameters["@petName"].Value;
            }
            return carPetName;
        }

        public void ProcessCreditRisk(bool throwEx, int custID)
        {
            // Look up current name based on customer ID.
            string fName = string.Empty;
            string lName = string.Empty;
            SqlCommand cmdSelect = new SqlCommand(string.Format("Select * from Customers where CustId = {0}",
                custID), sqlCN);
            using (SqlDataReader dr = cmdSelect.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    fName = (string)dr["FirstName"];
                    lName = (string)dr["LastName"];
                }
                else
                    return;
            }

            // Create command objectsthat represent each step of the operation.
            SqlCommand cmdRemove = new SqlCommand(
                string.Format("Delete from Customers where CustId = {0}",
                custID), sqlCN);

            SqlCommand cmdInsert = new SqlCommand(string.Format("Insert Into CreditRisks" +
                "(CustId, FirstName, LastName) Values" +
                "({0}, '{1}', '{2}'", custID, fName, lName), sqlCN);

            // You will get this from the connection object.
            SqlTransaction tx = null;
            try
            {
                tx = sqlCN.BeginTransaction();

                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;
                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();

                if (throwEx)
                {
                    throw new Exception("Sorry! Database error! Tx failed...");
                }

                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                tx.Rollback();
            }
        }
    }
}
