using System.Collections.Generic;
using System.Linq;
using Vehifleet.Data.Models;
using Vehifleet.Helper.Extensions;

namespace Vehifleet.API.QueryFilters
{
    public class VehicleModelFilter : IQueryFilter<VehicleModel>
    {
        public IEnumerable<string> Manufacturer { get; set; }

        public IQueryable<VehicleModel> Filter(IQueryable<VehicleModel> query)
        {
            if (Manufacturer.NotNullOrEmpty())
            {
                query = query.Where(vm => Manufacturer.Any(m => m == vm.Manufacturer));
            }

            return query;
        }
    }
}