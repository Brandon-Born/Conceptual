using System.Data.Entity;
using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure
{
    public interface IDomainContext
    {
        int SaveChanges();
        void Add<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Update<TEntity, TEntityDTO>(TEntityDTO dto)
            where TEntity : class, IEntity
            where TEntityDTO : class, IEntity;
        void Delete<TEntity>(int id) where TEntity : class, IEntity;

        IDbSet<Category> Categories { get; }
        IDbSet<Product> Products { get; }
    }
}
