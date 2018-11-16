using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Models;

namespace Vehifleet.Repositories
{
    public class LocationRepository : GenericRepository<Location, string>
    {
        public LocationRepository(VehifleetContext context) : base(context)
        {
        }

        public override async Task<Location> GetById(string id)
        {
            return await Set.SingleOrDefaultAsync(l => l.LocationCode == id);
        }

        public override async Task<bool> Exists(string id)
        {
            return await Set.AnyAsync(l => l.LocationCode == id);
        }
    }
}