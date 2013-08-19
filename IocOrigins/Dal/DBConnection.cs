using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins
{
    public class DbConnection
    {
        public string ConnectionString { get; private set; }

        public DbConnection(string connectionString)
        {
            Console.WriteLine("Opened connection to {0}", connectionString);
            ConnectionString = connectionString;
        }
    }
}
