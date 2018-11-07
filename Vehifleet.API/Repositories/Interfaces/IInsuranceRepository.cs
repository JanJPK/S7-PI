using System.Collections.Generic;
using System.Threading.Tasks;
using Vehifleet.Data.Models;

namespace Vehifleet.API.Repositories.Interfaces
{
    public interface IInsuranceRepository
    {
        Task<IEnumerable<Insurance>> Get();
        Task<IEnumerable<Insurance>> GetActive();
        Task<IEnumerable<Insurance>> GetById(int id);
        Task<IEnumerable<Insurance>> GetByVehicleId(int vehicleId);
        Task<IEnumerable<Insurance>> GetLatestInsurancesForVehicles();
    }
}