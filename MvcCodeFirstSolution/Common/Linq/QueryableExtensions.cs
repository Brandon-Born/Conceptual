using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Linq
{
    public static class QueryableExtensions
    {
        public static IIncluder Includer = new NullIncluder();

        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
        {
            return Includer.Include<T, TProperty>(source, path);
        }

        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, string path) where T : class
        {
            return Includer.Include<T, TProperty>(source, path);
        }
    }
}
