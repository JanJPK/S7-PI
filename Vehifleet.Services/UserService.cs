using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;
using Vehifleet.Services.Helper;
using Vehifleet.Services.Interfaces;

namespace Vehifleet.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<EmployeeIdentity> userManager;
        private readonly IGenericRepository<EmployeeIdentity, string> identityRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IRoleRepository roleRepository;
        private readonly JwtOptions jwtOptions;

        public UserService(UserManager<EmployeeIdentity> userManager,
                           IGenericRepository<EmployeeIdentity, string> identityRepository,
                           IEmployeeRepository employeeRepository,
                           IRoleRepository roleRepository,
                           IOptions<JwtOptions> jwtOptions)
        {
            this.userManager = userManager;
            this.identityRepository = identityRepository;
            this.employeeRepository = employeeRepository;
            this.roleRepository = roleRepository;
            this.jwtOptions = jwtOptions.Value;
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await roleRepository.Get().ToListAsync();
        }

        public async Task<IEnumerable<IdentityRole>> GetIdentities()
        {
            return await roleRepository.Get().ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await employeeRepository.GetById(id);
        }

        public async Task AddUserToRole(string userId, string roleId)
        {
            await roleRepository.AddUserToRole(userId, roleId);
        }

        // TODO: Refactor entire registering process with SecureString / byte[] for password       
        public async Task<bool> CreateUser(EmployeeIdentity identity, string password)
        {
            var result = await userManager.CreateAsync(identity, password);
            if (result.Succeeded)
            {
                await employeeRepository.Insert(new Employee {IdentityId = identity.Id, IsActive = true});
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Employee> Login(LoginCredentials credentials)
        {
            var identity = await userManager.FindByNameAsync(credentials.UserName);
            if (identity == null)
            {
                return null;
            }

            if (await userManager.CheckPasswordAsync(identity, credentials.Password))
            {
                var claims = await CreateClaims(identity);
                var token = CreateToken(claims);
                var employee = await employeeRepository.GetByUserName(identity.UserName);
                employee.Jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return employee;
            }
            else
            {
                return null;
            }
        }

        private async Task<IEnumerable<Claim>> CreateClaims(EmployeeIdentity identity)
        {
            //var genericIdentity = new GenericIdentity(identity.UserName, "Token");
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, identity.UserName),         // Subject
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //JWT ID                
            };

            var roles = await roleRepository.GetByUserId(identity.Id);
            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role.Name));
            }

            return claims;
        }

        private JwtSecurityToken CreateToken(IEnumerable<Claim> claims)
        {
            return new JwtSecurityToken(jwtOptions.Issuer,
                                        jwtOptions.Audience,
                                        claims,
                                        jwtOptions.NotBefore,
                                        jwtOptions.Expiration,
                                        jwtOptions.SigningCredentials);
        }
    }
}