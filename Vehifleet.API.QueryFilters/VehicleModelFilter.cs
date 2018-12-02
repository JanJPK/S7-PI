using System.Collections.Generic;
using System.Linq;
using Vehifleet.Data.Models;
using Vehifleet.Helper.Extensions;

namespace Vehifleet.API.QueryFilters
{
    public class VehicleModelFilter : IQueryFilter<VehicleModel>
    {
        public string Manufacturer { get; set; }

        public IQueryable<VehicleModel> Filter(IQueryable<VehicleModel> query)
        {
            if (Manufacturer.NotNullOrEmpty())
            {
                query = query.Where(vm => vm.Manufacturer == Manufacturer);
            }

            return query;
        }
    }
}