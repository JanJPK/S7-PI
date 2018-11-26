using System.Linq;
using Vehifleet.Data.Models;
using Vehifleet.Helper.Extensions;

namespace Vehifleet.API.QueryFilters
{
    public class InsuranceFilter : IQueryFilter<Insurance>
    {
        public int? VehicleId { get; set; }


        public IQueryable<Insurance> Filter(IQueryable<Insurance> query)
        {
            if (VehicleId.NotNullOrLessThanOne())
            {
                query = query.Where(i => i.VehicleId == VehicleId);
            }

            return query;
        }
    }
}