using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotConnectedLayer;
using System.Configuration;
using System.Data;

namespace AutoLotCUIClient
{
    class Program
    {
        /* This program allows the user to enter the following commands:
            * I: Inserts a new record into the Inventory table.
            * U: Updates an existing record in the Inventory table.
            * D: Deletes an existing record from the Inventory table.
            * L: Displays the current inventory using a data reader.
            * S: Shows these options to the user.
            * P: Looks up pet name from carID.
            * Q: Quits the program. */
        static void Main(string[] args)
        {

            Console.WriteLine("***** The AutoLot Console UI *****\n");

            // Get connection string from App.config
            string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            bool userDone = false;
            string userCommand = string.Empty;

            // Create our Inventory DAL object.
            InventoryDAL invDAL = new InventoryDAL();
            invDAL.OpenConnection(cnStr);

            //Keep asking for input until user presses the "Q" key.
            try
            {
                ShowInstructions();
                do
                {
                    Console.Write("\nPlease enter your command: ");
                    userCommand = Console.ReadLine();
                    Console.WriteLine();
                    switch (userCommand.ToUpper())
                    {
                        case "I":
                            InsertNewCar(invDAL);
                            break;
                        case "U":
                            UpdateCarPetName(invDAL);
                            break;
                        case "D":
                            DeleteCar(invDAL);
                            break;
                        case "L":
                            ListInventory(invDAL);
                            break;
                        case "S":
                            ShowInstructions();
                            break;
                        case "P":
                            LookupPetName(invDAL);
                            break;
                        case "Q":
                            userDone = true;
                            break;
                        default:
                            Console.WriteLine("Bad data! Try again");
                            break;
                    }
                } while (!userDone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                invDAL.CloseConnection();
            }
        }

        private static void LookupPetName(InventoryDAL invDAL)
        {
            Console.Write("Enter ID of Car to Lookup: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Petname of {0} is {1}.",
                id, invDAL.LookUpPetName(id).TrimEnd());
        }

        private static void ListInventory(InventoryDAL invDAL)
        {
            DataTable dt = invDAL.GetAllInventoryAsTable();
            DisplayTable(dt);
        }
        private static void DisplayTable(DataTable dt)
        {
            // Print out the column names.
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write(dt.Columns[curCol].ColumnName + "\t");
            }
            Console.WriteLine("\n-------------------------------------------");

            // Print the DataTable.
            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");                    
                }
                Console.WriteLine();
            }

        }
        private static void ListInventoryViaList(InventoryDAL invDAL)
        {
            List<NewCar> record = invDAL.GetAllInventoryAsList();
            foreach (NewCar c in record)
            {
                Console.WriteLine("CarID: {0}, Make: {1}, Color: {2}, PetName: {3}",
                    c.CarID, c.Make, c.Color, c.PetName);
            }
        }

        private static void DeleteCar(InventoryDAL invDAL)
        {
            // Get ID of car to delete.
            Console.Write("EnterID of Car to delete: ");
            int id = int.Parse(Console.ReadLine());

            // Catch referential integrity violation
            try
            {
                invDAL.DeleteCar(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateCarPetName(InventoryDAL invDAL)
        {
            int carID;
            string newCarPetName;

            Console.Write("Enter Car ID: ");
            carID = int.Parse(Console.ReadLine());
            Console.Write("Enter New Pet Name: ");
            newCarPetName = Console.ReadLine();            

            invDAL.UpdateCarPetName(carID, newCarPetName);
        }

        private static void InsertNewCar(InventoryDAL invDAL)
        {
            //Get user data.
            int newCarID;
            string newCarColor, newCarMake, newCarPetName;

            Console.Write("Enter Car ID: ");
            newCarID = int.Parse(Console.ReadLine());

            Console.Write("Enter Car Color: ");
            newCarColor = Console.ReadLine();

            Console.Write("Enter Car Make: ");
            newCarMake = Console.ReadLine();

            Console.Write("Enter Car Pet Name: ");
            newCarPetName = Console.ReadLine();

            // Insert data into access library
            invDAL.InsertAuto(newCarID, newCarColor, newCarMake, newCarPetName);
        }

        private static void ShowInstructions()
        {
            Console.WriteLine("I: Inserts a new car.");
            Console.WriteLine("U: Updates an existing car.");
            Console.WriteLine("D: Deletes an existing car.");
            Console.WriteLine("L: Lists current inventory.");
            Console.WriteLine("S: Shows these instructions.");
            Console.WriteLine("P: Looks up pet name.");
            Console.WriteLine("Q: Quits program.");
        }
    }
}
