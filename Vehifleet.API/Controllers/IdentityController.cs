//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Vehifleet.API.Repositories.Interfaces;
//using Vehifleet.API.Security;
//using Vehifleet.Data.Dtos;
//using Vehifleet.Data.Models;

//namespace Vehifleet.API.Controllers
//{
//    [Route("api")]
//    public class IdentityController : Controller
//    {
//        private readonly UserManager<EmployeeIdentity> userManager;
//        private readonly IEmployeeRepository employeeRepository;
//        private readonly IIdentityRepository identityRepository;
//        private readonly IJwtManager jwtManager;

//        public IdentityController(UserManager<EmployeeIdentity> userManager,
//                                  IEmployeeRepository employeeRepository,
//                                  IIdentityRepository identityRepository,
//                                  IJwtManager jwtManager)
//        {
//            this.userManager = userManager;
//            this.employeeRepository = employeeRepository;
//            this.identityRepository = identityRepository;
//            this.jwtManager = jwtManager;
//        }

//        [HttpGet("role")]
//        public async Task<IActionResult> CreateRole()
//        {                        
//            await identityRepository.InsertRole(new IdentityRole("Employee"));
//            await identityRepository.InsertRole(new IdentityRole("Administrator"));
//            await identityRepository.InsertRole(new IdentityRole("Manager"));
//            return Ok();
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] EmployeeIdentityDto employeeIdentityDto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var identity = Mapper.Map<EmployeeIdentity>(employeeIdentityDto);
//            var result = await userManager.CreateAsync(identity, employeeIdentityDto.Password);
//            if (result.Succeeded)
//            {
//                await employeeRepository.Insert(new Employee { IdentityId = identity.Id, IsActive = true });
//                await employeeRepository.Save();
//                return Ok("Account created");
//            }
//            else
//            {
//                return BadRequest();
//            }            
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody]SecurityCredentialsDto credentials)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var user = await userManager.FindByNameAsync(credentials.UserName);
//            if (user == null)
//            {
//                return BadRequest("Invalid username.");
//            }

//            if (await userManager.CheckPasswordAsync(user, credentials.Password))
//            {
//                //var identity = await Task.FromResult(jwtManager.GenerateClaimsIdentity(user.UserName, user.Id));                
//                //var jwt = await jwtManager.GenerateJwt(identity, credentials.UserName, new JsonSerializerSettings { Formatting = Formatting.Indented });
//                var jwt = jwtManager.GenerateJwt();
//                return new OkObjectResult(jwt);
//            }
//            else
//            {
//                return BadRequest("Invalid password.");
//            }
//        }
//    }
//}
