using System.Threading.Tasks;

namespace Vehifleet.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> CheckIfEmployeeExists(int id);
    }
}