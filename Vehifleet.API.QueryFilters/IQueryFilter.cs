using System.Linq;

namespace Vehifleet.API.QueryFilters
{
    public interface IQueryFilter<T>
    {
        IQueryable<T> Filter(IQueryable<T> query);
    }
}