using System.Collections.Generic;
using System.Threading.Tasks;
using Vehifleet.Data.Models;

namespace Vehifleet.API.Repositories.Interfaces
{
    public interface IInspectionRepository
    {
        Task<IEnumerable<Inspection>> Get();
        Task<IEnumerable<Inspection>> GetActive();
        Task<IEnumerable<Inspection>> GetById(int id);
        Task<IEnumerable<Inspection>> GetByVehicleId(int vehicleId);
        Task<IEnumerable<Inspection>> GetLatestInspectionsForVehicles();
    }
}