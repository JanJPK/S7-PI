using System.Collections.Generic;
using System.Threading.Tasks;
using Vehifleet.API.QueryFilters;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> Get(VehicleFilter filter);
        Task<Vehicle> GetById(int id);
        Task Update(Vehicle vehicle);
        Task UpdateStatus(int id, VehicleStatus status);
    }
}