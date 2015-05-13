using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace FactoryMethod
{
    public class SqlServerDatabase : IDatabase
    {
        private SqlCommand command;
        private SqlConnection connection;

        public IDbCommand Command
        {

            get
            {
                if (command == null)
                {
                    command = new SqlCommand();
                    command.Connection = (SqlConnection)Connection;
                }
                return command;
            }
        }

        public IDbConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["OleDBConnectionString"].ConnectionString;
                    connection = new SqlConnection(connectionString);
                }
                return connection;
            }
        }
    }
}
