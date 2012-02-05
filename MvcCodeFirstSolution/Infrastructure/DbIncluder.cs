using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Common.Linq;

namespace Infrastructure
{
    internal class DbIncluder : IIncluder
    {
        public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
        {
            return DbExtensions.Include(source, path);
        }

        public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, string path) where T : class
        {
            return DbExtensions.Include(source, path);
        }
    }
}
