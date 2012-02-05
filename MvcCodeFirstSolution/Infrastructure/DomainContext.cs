using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Common.Linq;
using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Mappings;
using System;

namespace Infrastructure
{
    public class DomainContext : DbContext, IDomainContext
    {
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Product> Products { get; set; }

        static DomainContext()
        {            
            QueryableExtensions.Includer = new DbIncluder();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();   // metadata is used to track if database was modified.  we don't care since we are using DatabaseInitilizer.
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new PriceMap());
        }

        #region Boilerplate

        public void Add<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            Set<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(int id) where TEntity : class, IEntity
        {
            var entity = Set<TEntity>().Find(id);
            Entry(entity).State = EntityState.Deleted;
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            Entry(entity).State = EntityState.Modified;
        }

        #endregion Boilerplate

        public void Update<TEntity, TEntityDTO>(TEntityDTO dto) where TEntity: class, IEntity
            where TEntityDTO : class, IEntity  
        {
            var entity = Set<TEntity>().Find(dto.Id);
            var entry = base.Entry(entity);

            entry.CurrentValues.SetValues(dto);
        }
    }
}
