using System.Collections.Generic;
using System.Linq;
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
            //Context.UserRoles.Add(new IdentityUserRole<string>
            //{
            //    RoleId = roleId,
            //    UserId = userId
            //});
            //await Context.SaveChangesAsync();
        }

        // TODO: Optimize so its faster
        public async Task<IEnumerable<IdentityRole>> GetByUserId(string userId)
        {
            var query = Context.Roles
                               .Join(Context.UserRoles,
                                           r => r.Id,
                                           ur => ur.RoleId,
                                           (r, ur) => new
                                           {
                                               IdentityRole = r,
                                               IdentityUserRole = ur
                                           })
                               .Where(j => j.IdentityUserRole.UserId == userId)
                               .Select(j => j.IdentityRole);
            return await query.ToListAsync();            
        }

        public override Task<bool> Exists(string id)
        {
            return Set.AnyAsync(r => r.Id == id);
        }
    }
}