using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Vehifleet.API.DbAccess;
using Vehifleet.API.Repositories.Interfaces;

namespace Vehifleet.API.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly VehifleetContext context;

        public IdentityRepository(VehifleetContext context)
        {
            this.context = context;
        }

        public async Task<int> InsertRole(IdentityRole role)
        {
            context.Roles.Add(role);
            return await context.SaveChangesAsync();
        }

        
    }
}
