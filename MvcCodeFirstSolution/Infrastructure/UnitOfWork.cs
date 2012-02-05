using System;
using Domain.Abstractions;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDomainContext _context;


        public UnitOfWork(IDomainContext context)
        {
            if (context == null)
                throw new ArgumentNullException();

            _context = context; 
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
