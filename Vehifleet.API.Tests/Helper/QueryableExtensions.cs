using System;
using System.Linq;
using System.Linq.Expressions;

namespace Vehifleet.API.Tests.Helper
{
    /// <summary>
    ///     http://blogs.clariusconsulting.net/kzu/how-to-design-a-unit-testable-domain-model-with-entity-framework-code-first/
    /// </summary>
    public static class QueryableExtensions
    {
        internal static IIncluder Includer = new NullIncluder();

        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
        {
            return Includer.Include(source, path);
        }

        public interface IIncluder
        {
            IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class;
        }

        internal class NullIncluder : IIncluder
        {
            public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
            {
                return source;
            }
        }
    }
}
