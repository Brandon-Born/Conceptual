using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Linq
{
    internal class NullIncluder : IIncluder
    {
        public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
        {
            return source;  // do nothing
        }

        public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, string path) where T : class
        {
            return source;  // do nothing
        }
    }
}
