using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Vehifleet.Data.Models;
using Vehifleet.Services.Helper;

namespace Vehifleet.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(EmployeeIdentity identity, string password);
        Task<Employee> Login(LoginCredentials credentials);
        Task<IEnumerable<IdentityRole>> GetIdentities();
        Task<IEnumerable<IdentityRole>> GetRoles();
        Task<Employee> GetEmployeeById(int id);
    }
}