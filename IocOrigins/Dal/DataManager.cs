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
                    _connection = new DbConnection(ConnectionString);
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

        public bool ExecuteCommand<TCommand, TParameter>(TParameter param)
            where TCommand: DataCommandBase<TParameter>, new()
        {
            var command  = new TCommand();
            command.Connection = Connection;
            command.Data = Data;

            try
            {
                command.DoWork(param);
            }
            catch (DataCommandException ex)
            {
                Console.WriteLine("Exception occurred during command. Message: {0}", ex.Message);
                return false;
            }

            if (command.Transaction == null)
            {
                Console.WriteLine("Command executed without transaction.");
            }
            else if (!command.Transaction.Committed || command.Transaction.Cancelled)
            {
                Console.WriteLine("Command completed without either committing or cancelling transaction.");
            }

            return true;
        }
    }
}
