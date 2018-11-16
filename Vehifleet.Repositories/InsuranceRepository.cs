using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Models;

namespace Vehifleet.Repositories
{
    public class InsuranceRepository : GenericRepository<Insurance, int>
    {
        public InsuranceRepository(VehifleetContext context) : base(context)
        {
        }

        public override async Task<Insurance> GetById(int id)
        {
            return await Set.SingleOrDefaultAsync(i => i.Id == id);
        }

        public override async Task<bool> Exists(int id)
        {
            return await Set.AnyAsync(i => i.Id == id);
        }
    }
}