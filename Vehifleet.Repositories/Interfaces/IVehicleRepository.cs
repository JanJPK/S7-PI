using System.Threading.Tasks;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Repositories.Interfaces
{
    public interface IVehicleRepository : IGenericRepository<Vehicle, int>
    {        
        Task UpdateVehicleStatusById(int id, VehicleStatus status);
    }
}