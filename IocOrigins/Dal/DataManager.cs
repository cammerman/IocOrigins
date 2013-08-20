using IocOrigins.DataCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.Dal
{
    public class DataManager
    {
        protected string ConnectionString { get; private set; }

        private DbConnection _connection;

        protected DbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new DbConnection(ConnectionString, Data);
                }

                return _connection;
            }
        }

        public List<object> Data { get; private set; }

        public DataManager(string connectionString, IEnumerable<object> data)
        {
            ConnectionString = connectionString;
            Data = data.ToList();
        }

        public IDataTransaction BeginTransaction()
        {
            return new DataTransaction(Connection);
        }
    }
}
