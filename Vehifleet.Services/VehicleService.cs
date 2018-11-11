using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.API.QueryFilters;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;
using Vehifleet.Repositories.Interfaces;
using Vehifleet.Services.Interfaces;

namespace Vehifleet.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> Get(VehicleFilter filter)
        {
            var query = filter.Filter(vehicleRepository.Get());

            return await query
                        .Include(v => v.VehicleSpecification)
                        .Include(v => v.Insurances)
                        .Include(v => v.Inspections)
                        .Include(v => v.Location)
                        .ToListAsync();
        }

        public async Task<Vehicle> GetById(int id)
        {
            return await vehicleRepository.GetById(id);
        }

        public async Task Update(Vehicle vehicle)
        {
            await vehicleRepository.Update(vehicle);
        }

        public async Task UpdateStatus(int id, VehicleStatus status)
        {
            await vehicleRepository.UpdateVehicleStatusById(id, status);
        }
    }
}