using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.Dal
{
    public class DbConnection : IConnection
    {
        public string ConnectionString { get; private set; }

        protected virtual IDataStore DataStore { get; private set; }

        public IList<object> Data
        {
            get { return DataStore.Data; }
        }

        public DbConnection(string connectionString, IDataStore data)
        {
            Console.WriteLine("Opened connection to {0}", connectionString);
            ConnectionString = connectionString;
            DataStore = data;
        }
    }
}
