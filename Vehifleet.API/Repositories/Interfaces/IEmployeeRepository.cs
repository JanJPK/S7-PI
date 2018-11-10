using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Vehifleet.Data.Models;

namespace Vehifleet.API.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> CheckIfEmployeeExists(int id);
        Task<EntityEntry<Employee>> Insert(Employee employee);
        Task<int> Save();
    }
}