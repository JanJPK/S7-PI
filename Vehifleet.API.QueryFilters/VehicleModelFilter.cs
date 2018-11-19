using System.Linq;
using Vehifleet.Data.Models;

namespace Vehifleet.API.QueryFilters
{
    public class VehicleModelFilter : IQueryFilter<VehicleModel>
    {
        public IQueryable<VehicleModel> Filter(IQueryable<VehicleModel> query)
        {
            return query;
        }
    }
}