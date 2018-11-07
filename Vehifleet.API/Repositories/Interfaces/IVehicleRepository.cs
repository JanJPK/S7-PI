using System.Collections.Generic;
using System.Threading.Tasks;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.API.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> Get();
        Task<IEnumerable<Vehicle>> GetByStatus(VehicleStatus status = VehicleStatus.Available);
        Task<IEnumerable<Vehicle>> GetByLocationCode(string locationCode);
        Task<Vehicle> GetById(int id);
    }
}