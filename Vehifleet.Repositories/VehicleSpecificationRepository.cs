using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Models;

namespace Vehifleet.Repositories
{
    public class VehicleSpecificationRepository : GenericRepository<VehicleSpecification, int>
    {
        public VehicleSpecificationRepository(VehifleetContext context) : base(context)
        {
        }

        public override Task<VehicleSpecification> GetById(int id)
        {
            return Set.SingleOrDefaultAsync(vs => vs.Id == id);
        }

        public override Task<bool> Exists(int id)
        {
            return Set.AnyAsync(vs => vs.Id == id);
        }
    }
}