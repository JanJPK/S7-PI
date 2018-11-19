using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.Repositories
{
    public class IdentityRepository : GenericRepository<EmployeeIdentity, string>
    {
        public IdentityRepository(VehifleetContext context) : base(context)
        {
        }

        public override Task<EmployeeIdentity> GetById(string id)
        {
            return Set.SingleOrDefaultAsync(i => i.Id == id);
        }

        public override Task<bool> Exists(string id)
        {
            return Set.AnyAsync(i => i.Id == id);
        }
    }
}