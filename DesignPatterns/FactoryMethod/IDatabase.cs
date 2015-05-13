using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;

namespace FactoryMethod
{
    public interface IDatabase
    {
        IDbCommand Command
        {
            get;
        }

        IDbConnection Connection
        {
            get;
        }
    }
}
