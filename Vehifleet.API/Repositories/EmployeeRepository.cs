using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Vehifleet.API.DbAccess;
using Vehifleet.API.Repositories.Interfaces;
using Vehifleet.Data.Models;

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

        public async Task<EntityEntry<Employee>> Insert(Employee employee)
        {
            return await context.Employees.AddAsync(employee);            
        }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }
    }
}
