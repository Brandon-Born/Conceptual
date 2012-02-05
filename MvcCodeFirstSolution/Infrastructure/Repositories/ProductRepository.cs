using System.Linq;
using Domain.Abstractions;
using Domain.Entities;
using System;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly IDomainContext _context;

        public ProductRepository(IDomainContext context)
        {
            _context = context;
        }

        public void Create(Product entity)
        {
            _context.Add(entity);
        }

        public void Delete(int id)
        {
            _context.Delete<Product>(id);
        }

        public void Update(Product entity)
        {
            _context.Update(entity);
        }

        public Product Find(int id)
        {
            return _context.Products.Find(id);
        }

        public IQueryable<Product> FindAll()
        {
            return _context.Products;
        }

        public void Dispose()
        {
            int i = 0;
        }
    }
}
