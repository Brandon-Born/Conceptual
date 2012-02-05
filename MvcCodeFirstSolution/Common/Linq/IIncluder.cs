using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Linq
{
    public interface IIncluder
    {
        IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class;
        IQueryable<T> Include<T, TProperty>(IQueryable<T> source, string path) where T : class;
    }
}
