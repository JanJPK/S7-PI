using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.Services
{
    public class UserService
    {
        private readonly IIdentityRepository identityRepository;
        private readonly IRoleRepository roleRepository;

        public UserService(IIdentityRepository identityRepository, IRoleRepository roleRepository)
        {
            this.identityRepository = identityRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await roleRepository.Get().ToListAsync();
        }
        public async Task<IEnumerable<IdentityRole>> GetIdentities()
        {
            return await roleRepository.Get().ToListAsync();
        }
    }
}
