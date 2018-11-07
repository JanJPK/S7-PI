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
    public class InspectionRepository : IInspectionRepository
    {
        private readonly VehifleetContext context;

        public InspectionRepository(VehifleetContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Inspection>> Get()
        {
            return await context.Inspections                                
                                .ToListAsync();
        }

        public async Task<IEnumerable<Inspection>> GetActive()
        {
            return await context.Inspections
                                .Where(i => i.ExpirationDate > DateTime.UtcNow)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Inspection>> GetByVehicleId(int vehicleId)
        {
            return await context.Inspections
                                .Where(i => i.VehicleId == vehicleId)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Inspection>> GetLatestInspectionsForVehicles()
        {
            return await context.Inspections
                                .GroupBy(i => i.VehicleId)
                                .Select(g => g.OrderBy(i => i.ExpirationDate)
                                              .First())
                                .ToListAsync();
        }

        public async Task<IEnumerable<Inspection>> GetById(int id)
        {
            return await context.Inspections
                                .Where(i => i.Id == id)
                                .ToListAsync();
        }
    }
}
