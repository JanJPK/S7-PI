using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(VehifleetContext context) : base(context)
        {
        }

        public override Task<Employee> GetById(int id)
        {
            return Set.Include(e => e.Identity)
                      .SingleOrDefaultAsync(e => e.Id == id);
        }
    }
}