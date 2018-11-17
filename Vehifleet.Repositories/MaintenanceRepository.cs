using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.Repositories
{
    public class MaintenanceRepository : GenericRepository<Maintenance, int>
    {
        public MaintenanceRepository(VehifleetContext context) : base(context)
        {
        }

        public override async Task<Maintenance> GetById(int id)
        {
            return await Set.SingleOrDefaultAsync(m => m.Id == id);
        }

        public override async Task<bool> Exists(int id)
        {
            return await Set.AnyAsync(m => m.Id == id);
        }
    }
}