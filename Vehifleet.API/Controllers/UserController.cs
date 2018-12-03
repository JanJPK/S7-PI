using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;
using Vehifleet.Services.Helper;
using Vehifleet.Services.Interfaces;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUserService userService;

        public UserController(IEmployeeRepository employeeRepository, 
                              IUserService userService)
        {
            this.employeeRepository = employeeRepository;
            this.userService = userService;
        }

        [HttpGet("employees/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<EmployeeDto>(employee));
            }
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
                
                return Ok(Mapper.Map<EmployeeDto>(employee));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}