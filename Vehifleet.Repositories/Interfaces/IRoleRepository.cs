using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Vehifleet.Repositories.Interfaces
{
    public interface IRoleRepository : IGenericRepository<IdentityRole, string>
    {
        Task AddUserToRole(string userId, string roleId);        
    }
}