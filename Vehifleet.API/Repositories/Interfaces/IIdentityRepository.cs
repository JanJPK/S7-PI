using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Vehifleet.API.Repositories.Interfaces
{
    public interface IIdentityRepository
    {
        Task<int> InsertRole(IdentityRole role);
    }
}