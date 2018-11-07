using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.API.DbAccess;

namespace Vehifleet.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly VehifleetContext context;

        public EmployeeRepository(VehifleetContext context)
        {
            this.context = context;
        }

        public async Task<bool> CheckIfEmployeeExists(int id)
        {
            return await context.Employees.AnyAsync(e => e.Id == id);
        }
    }
}
