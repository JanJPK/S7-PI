using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Models;

namespace Vehifleet.Repositories
{
    public class InspectionRepository : GenericRepository<Inspection, int>
    {
        public InspectionRepository(VehifleetContext context) : base(context)
        {
        }

        public override async Task<Inspection> GetById(int id)
        {
            return await Set.SingleOrDefaultAsync(i => i.Id == id);
        }

        public override async Task<bool> Exists(int id)
        {
            return await Set.AnyAsync(i => i.Id == id);
        }
    }
}