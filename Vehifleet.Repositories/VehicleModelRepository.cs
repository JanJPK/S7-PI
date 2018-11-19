using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Models;

namespace Vehifleet.Repositories
{
    public class VehicleModelRepository : GenericRepository<VehicleModel, int>
    {
        public VehicleModelRepository(VehifleetContext context) : base(context)
        {
        }

        public override Task<VehicleModel> GetById(int id)
        {
            return Set.SingleOrDefaultAsync(vs => vs.Id == id);
        }

        public override Task<bool> Exists(int id)
        {
            return Set.AnyAsync(vs => vs.Id == id);
        }
    }
}