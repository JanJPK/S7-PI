using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.API.DbAccess;
using Vehifleet.API.Repositories.Interfaces;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.API.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehifleetContext context;

        public VehicleRepository(VehifleetContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Vehicle>> Get()
        {
            return await context.Vehicles
                                .Include(v => v.VehicleSpecification)
                                .Include(v => v.Insurances)
                                .Include(v => v.Inspections)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetByStatus(VehicleStatus status)
        {
            return await context.Vehicles
                                .Where(v => v.Status == status)
                                .Include(v => v.VehicleSpecification)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetByLocationCode(string locationCode)
        {
            return await context.Vehicles
                                .Where(v => v.LocationCode == locationCode)
                                .Include(v => v.VehicleSpecification)
                                .ToListAsync();
        }

        public async Task<Vehicle> GetById(int id)
        {
            return await context.Vehicles
                                .Include(v => v.VehicleSpecification)
                                .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}