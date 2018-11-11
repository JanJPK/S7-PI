using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehifleet.API.QueryFilters
{
    public interface IFilter<T>
    {
        IQueryable<T> FilterQuery(IQueryable<T> query);

    }
}
