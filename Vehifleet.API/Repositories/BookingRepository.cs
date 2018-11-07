using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.API.DbAccess;
using Vehifleet.Data.Models;

namespace Vehifleet.API.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly VehifleetContext context;

        public BookingRepository(VehifleetContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Booking>> Get()
        {
            return await context.Bookings
                                .Include(b => b.Vehicle)
                                .Include(b => b.Employee)
                                .Include(b => b.Manager)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetByEmployeeId(int employeeId)
        {
            return await context.Bookings
                                .Where(b => b.EmployeeId == employeeId)
                                .Include(b => b.Vehicle)
                                .Include(b => b.Employee)
                                .Include(b => b.Manager)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetById(int id)
        {
            return await context.Bookings
                                .Where(b => b.Id == id)
                                .Include(b => b.Vehicle)
                                .Include(b => b.Employee)
                                .Include(b => b.Manager)
                                .ToListAsync();
        }
    }
}