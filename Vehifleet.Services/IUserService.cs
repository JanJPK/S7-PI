using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Vehifleet.Data.Models;
using Vehifleet.Services.Helper;

namespace Vehifleet.Services
{
    public interface IUserService
    {
        Task<bool> CreateUser(EmployeeUser identity, string password);
        Task<string> Login(LoginCredentials credentials);
        Task<IEnumerable<IdentityRole>> GetIdentities();
        Task<IEnumerable<IdentityRole>> GetRoles();
    }
}