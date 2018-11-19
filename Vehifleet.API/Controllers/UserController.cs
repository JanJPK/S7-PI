using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Services.Helper;
using Vehifleet.Services.Interfaces;

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
        public async Task<IActionResult> Register([FromBody] EmployeeRegisterDto dto)
        {
            var identity = Mapper.Map<EmployeeIdentity>(dto);

            if (await userService.CreateUser(identity, dto.Password))
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
            var employee = await userService.Login(credentials);
            if (employee != null)
            {
                
                return Ok(Mapper.Map<EmployeeLoginDto>(employee));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}