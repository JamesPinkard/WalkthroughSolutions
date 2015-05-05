﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.OleDb;



namespace AbstractFactory
{
    class OleDBDatabase : Database
    {
        private System.Data.Common.DbConnection connection = null;
        private System.Data.Common.DbCommand command = null;

        public override System.Data.Common.DbConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["OleDBConnectionString"].ConnectionString;
                    connection = new OleDbConnection(connectionString);
                }
                return connection;
            }
            set
            {
                connection = value;
            }
        }

        public override System.Data.Common.DbCommand Command
        {
            get
            {
                if (command == null)
                {
                    command = new OleDbCommand();
                    command.Connection = Connection;
                }
                return command;
            }
            set
            {
                command = value;
            }
        }
    }
}
