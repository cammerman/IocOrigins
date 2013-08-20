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
        public string ConnectionString { get; set; }

        protected Func<string, IConnection> CreateConnection { get; private set; }

        private IConnection _connection;

        protected IConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = CreateConnection(ConnectionString);
                }

                return _connection;
            }
        }

        public List<object> Data { get; private set; }

        public DataManager(Func<string, IConnection> createConnection)
        {
            CreateConnection = createConnection;
        }

        public IDataTransaction BeginTransaction()
        {
            return new DataTransaction(Connection);
        }
    }
}
