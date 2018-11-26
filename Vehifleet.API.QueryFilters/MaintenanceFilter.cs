using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehifleet.Data.Models;
using Vehifleet.Helper.Extensions;

namespace Vehifleet.API.QueryFilters
{
    public class MaintenanceFilter : IQueryFilter<Maintenance>
    {
        public int? VehicleId { get; set; }

        public IQueryable<Maintenance> Filter(IQueryable<Maintenance> query)
        {
            if (VehicleId.NotNullOrLessThanOne())
            {
                query = query.Where(m => m.VehicleId == VehicleId);
            }

            return query;
        }
    }
}
