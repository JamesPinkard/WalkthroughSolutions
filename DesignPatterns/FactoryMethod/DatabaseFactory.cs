using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod
{
    public class DatabaseFactory
    {
        public static IDatabase CreateDatabase(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.SqlServer:
                    return new SqlServerDatabase();
                    // Here is where you might use a builder pattern
                case DatabaseType.OleDb:
                    return new OleDBDatabase();                    
                default:
                    return new SqlServerDatabase();                    
            }
        }
    }
}
