using System.Linq;
using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDomainContext _domainContext;


        public CategoryRepository(IDomainContext domainContext)
        {
            _domainContext = domainContext;
        }

        public void Create(Category category)
        {
            _domainContext.Add(category);
        }

        public void Delete(int id)
        {
            _domainContext.Delete<Category>(id);
        }

        public void Update(Category category)
        {
            _domainContext.Update(category);
        }

        public Category Find(int id)
        {
            return _domainContext.Categories.Find(id);
        }

        public IQueryable<Category> FindAll()
        {
            return _domainContext.Categories as IQueryable<Category>;
        }
    }
}
