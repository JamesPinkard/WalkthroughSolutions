using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.OleDb;

namespace FactoryMethod
{
    public class OleDBDatabase : IDatabase
    {
        private OleDbCommand command;
        private OleDbConnection connection;


        public IDbCommand Command
        {

            get
            {
                if (command == null)
                {
                    command = new OleDbCommand();
                    command.Connection = (OleDbConnection)Connection;
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
                    string connectionString = ConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString;
                    connection = new OleDbConnection(connectionString);
                }
                return connection;
            }
        }
    }
}
