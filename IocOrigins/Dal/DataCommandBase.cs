using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.Dal
{
    public abstract class DataCommandBase<TParameter>
    {
        private DbConnection _connection;
        public DbConnection Connection {
            get { return _connection; }
            set
            {
                if (_connection != null)
                {
                    throw new InvalidOperationException("Connection can only be initialized once.");
                }

                _connection = value;
            }
        }

        private List<object> _data;
        public List<object> Data {
            get { return _data; }
            set
            {
                if (_data != null)
                {
                    throw new InvalidOperationException("Data can only be initialized once.");
                }

                _data = value;
            }
        }

        protected virtual void OpenTransaction(string name)
        {
            Transaction = new DbTransaction(name);
        }

        public DbTransaction Transaction { get; private set; }
        
        protected virtual TEntity Load<TEntity>(int id)
            where TEntity : IEntity
        {
            Console.WriteLine("Opened entity with id {0}", id);
            return
                Data
                    .OfType<TEntity>()
                    .SingleOrDefault(entity => entity.Id == id);
        }

        protected virtual void Save<TEntity>(TEntity t)
            where TEntity : IEntity
        {
            Console.WriteLine("Saved entity with id {0}", t.Id);
            Data.Add(t);
        }

        protected virtual TEntity[] Find<TEntity>(Func<TEntity, bool> filter)
            where TEntity : IEntity
        {
            Console.WriteLine("Loaded entities with filter {0}", filter.ToString());
            
            return
                Data
                    .OfType<TEntity>()
                    .Where(filter)
                    .ToArray();
        }

        protected virtual void Delete<TEntity>(TEntity entity)
        {
            Data.Remove(entity);
        }

        public abstract void DoWork(TParameter param);
    }
}
