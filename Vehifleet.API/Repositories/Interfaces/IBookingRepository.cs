using System.Collections.Generic;
using System.Threading.Tasks;
using Vehifleet.Data.Models;

namespace Vehifleet.API.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> Get();
        Task<IEnumerable<Booking>> GetByEmployeeId(int employeeId);
        Task<IEnumerable<Booking>> GetById(int id);
    }
}