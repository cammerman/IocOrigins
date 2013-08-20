using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.Dal
{
    public class DbConnection
    {
        public string ConnectionString { get; private set; }

        public List<object> Data { get; private set; }

        public DbConnection(string connectionString, List<object> data)
        {
            Console.WriteLine("Opened connection to {0}", connectionString);
            ConnectionString = connectionString;
            Data = data;
        }
    }
}
