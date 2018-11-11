using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(VehifleetContext context) : base(context)
        {
        }

        public override async Task<Vehicle> GetById(int id)
        {
            return await Set
                        .Include(v => v.VehicleSpecification)
                        .Include(v => v.Insurances)
                        .Include(v => v.Inspections)
                        .Include(v => v.Location)
                        .AsNoTracking()
                        .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task UpdateVehicleStatusById(int id, VehicleStatus status)
        {
            var vehicle = await Set.SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle != null)
            {
                vehicle.Status = status;
            }

            await Update(vehicle);
        }
    }
}