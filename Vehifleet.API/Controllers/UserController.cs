using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Services;
using Vehifleet.Services.Helper;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] EmployeeIdentityDto identityDto)
        {
            var identity = Mapper.Map<EmployeeUser>(identityDto);

            if (await userService.CreateUser(identity, identityDto.Password))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
        {
            var token =  await userService.Login(credentials);
            if (!string.IsNullOrEmpty(token))
            {
                return Ok(token);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}