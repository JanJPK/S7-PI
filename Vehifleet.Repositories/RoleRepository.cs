using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.Repositories
{
    public class RoleRepository : GenericRepository<IdentityRole, string>, IRoleRepository
    {
        public RoleRepository(VehifleetContext context) : base(context)
        {
        }

        public override async Task<IdentityRole> GetById(string id)
        {
            return await Set.SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddUserToRole(string userId, string roleId)
        {
            Context.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });
            await Context.SaveChangesAsync();
        }
    }
}