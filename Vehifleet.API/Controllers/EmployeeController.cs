using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Vehifleet.API.Repositories;
using Vehifleet.API.Repositories.Interfaces;
using Vehifleet.API.Security;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;

namespace Vehifleet.API.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly UserManager<EmployeeIdentity> userManager;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IJwtManager jwtManager;

        public EmployeeController(UserManager<EmployeeIdentity> userManager, 
                                  IEmployeeRepository employeeRepository,
                                  IJwtManager jwtManager)
        {
            this.userManager = userManager;
            this.employeeRepository = employeeRepository;
            this.jwtManager = jwtManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] EmployeeIdentityDto employeeIdentityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = Mapper.Map<EmployeeIdentity>(employeeIdentityDto);
            var result = await userManager.CreateAsync(identity, employeeIdentityDto.Password);
            if (result.Succeeded)
            {
                await employeeRepository.Insert(new Employee {IdentityId = identity.Id, IsActive = true});
                await employeeRepository.Save();
                return Ok("Account created");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]SecurityCredentialsDto credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
            if (identity == null)
            {
                return BadRequest("login_failure");
            }

            //var jwt = await jwtManager.GenerateJwt(identity, credentials.UserName,  new JsonSerializerSettings { Formatting = Formatting.Indented });
            //return new OkObjectResult(jwt);
            return Ok();
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await userManager.CheckPasswordAsync(userToVerify, password))
            {
                //return await Task.FromResult(jwtManager.GenerateClaimsIdentity(userName, userToVerify.Id));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }

    }
}
