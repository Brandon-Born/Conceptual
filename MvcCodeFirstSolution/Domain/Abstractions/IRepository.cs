using System.Collections.Generic;
using System.Linq;

namespace Domain.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        void Create(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        TEntity Find(int id);
        IQueryable<TEntity> FindAll();
    }
}
