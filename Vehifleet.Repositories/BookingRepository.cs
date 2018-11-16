using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.Repositories
{
    public class BookingRepository : GenericRepository<Booking, int>, IBookingRepository
    {
        public BookingRepository(VehifleetContext context) : base(context)
        {
        }

        public override Task<Booking> GetById(int id)
        {
            return Set
                  .Include(b => b.Employee)
                  .Include(b => b.Manager)
                  .Include(b => b.Vehicle)
                  .AsNoTracking()
                  .SingleOrDefaultAsync(b => b.Id == id);
        }

        /// <summary>
        ///     Updates booking status; also updates notes if required.
        /// </summary>
        /// <param name="id">Booking ID.</param>
        /// <param name="status">Booking status.</param>
        /// <param name="notes">Additional notes from manager.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateBookingStatusById(int id, BookingStatus status, string notes)
        {
            var booking = await Set.SingleOrDefaultAsync(b => b.Id == id);

            if (booking != null)
            {
                booking.Status = status;

                if (!string.IsNullOrEmpty(notes))
                {
                    booking.Notes = notes;
                }
            }

            await Update(booking);
        }

        public override Task<bool> Exists(int id)
        {
            return Set.AnyAsync(b => b.Id == id);
        }
    }
}