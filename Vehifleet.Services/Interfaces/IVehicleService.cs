using System.Collections.Generic;
using System.Threading.Tasks;
using Vehifleet.API.QueryFilters;
using Vehifleet.Data.Models;

namespace Vehifleet.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> Get(VehicleFilter filter);
    }
}