using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Models;

namespace Vehifleet.Repositories
{
    public class BookingRepository : GenericRepository<Booking, int>
    {
        public BookingRepository(VehifleetContext context) : base(context)
        {
        }

        public override Task<Booking> GetById(int id)
        {
            return Set
                  .Include(b => b.Employee)
                  .Include(b => b.Vehicle)
                  .AsNoTracking()
                  .SingleOrDefaultAsync(b => b.Id == id);
        }

        public override Task<bool> Exists(int id)
        {
            return Set.AnyAsync(b => b.Id == id);
        }
    }
}