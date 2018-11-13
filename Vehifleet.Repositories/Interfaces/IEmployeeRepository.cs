using System.Threading.Tasks;
using Vehifleet.Data.Models;

namespace Vehifleet.Repositories.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee, int>
    {
        Task<Employee> GetByUserName(string userName);
    }
}