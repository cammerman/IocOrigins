using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.Dal
{
    public interface IDataTransaction : IDisposable
    {
        TEntity Load<TEntity>(int id)
            where TEntity : IEntity;

        void Save<TEntity>(TEntity t)
            where TEntity : IEntity;

        TEntity[] Find<TEntity>(Func<TEntity, bool> filter)
            where TEntity : IEntity;
        
        void Delete<TEntity>(TEntity entity)
            where TEntity : IEntity;
        
        void Commit();
        void Cancel();
    }
}
