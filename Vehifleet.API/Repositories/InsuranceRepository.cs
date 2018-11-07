using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.API.DbAccess;
using Vehifleet.API.Repositories.Interfaces;
using Vehifleet.Data.Models;

namespace Vehifleet.API.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly VehifleetContext context;

        public InsuranceRepository(VehifleetContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Insurance>> Get()
        {
            return await context.Insurances
                                .ToListAsync();
        }

        public async Task<IEnumerable<Insurance>> GetActive()
        {
            return await context.Insurances
                                .Where(i => i.ExpirationDate > DateTime.UtcNow)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Insurance>> GetByVehicleId(int vehicleId)
        {
            return await context.Insurances
                                .Where(i => i.VehicleId == vehicleId)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Insurance>> GetLatestInsurancesForVehicles()
        {
            return await context.Insurances
                                .GroupBy(i => i.VehicleId)
                                .Select(g => g.OrderBy(i => i.ExpirationDate)
                                              .First())
                                .ToListAsync();
        }

        public async Task<IEnumerable<Insurance>> GetById(int id)
        {
            return await context.Insurances
                                .Where(i => i.Id == id)
                                .ToListAsync();
        }
    }
}
