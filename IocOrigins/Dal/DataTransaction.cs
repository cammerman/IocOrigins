using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.Dal
{
    public class DataTransaction : IDataTransaction
    {
        public DataTransaction(IEnumerable<object> data)
        {
            Data = data.ToList();
        }

        public List<object> Data { get; private set; }
        
        public virtual TEntity Load<TEntity>(int id)
            where TEntity : IEntity
        {
            Console.WriteLine("Opened entity with id {0}", id);
            return
                Data
                    .OfType<TEntity>()
                    .SingleOrDefault(entity => entity.Id == id);
        }

        public virtual void Save<TEntity>(TEntity t)
            where TEntity : IEntity
        {
            Console.WriteLine("Saved entity with id {0}", t.Id);
            Data.Add(t);
        }

        public virtual TEntity[] Find<TEntity>(Func<TEntity, bool> filter)
            where TEntity : IEntity
        {
            Console.WriteLine("Loaded entities with filter {0}", filter.ToString());
            
            return
                Data
                    .OfType<TEntity>()
                    .Where(filter)
                    .ToArray();
        }

        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : IEntity
        {
            Data.Remove(entity);
        }

        public bool Committed
        {
            get;
            private set;
        }

        public bool Cancelled
        {
            get;
            private set;
        }

        public void Commit()
        {
            Committed = true;
            Console.WriteLine("Transaction committed.");
        }

        public void Cancel()
        {
            Cancelled = true;
            Console.WriteLine("Transaction cancelled.");
        }
    }
}
