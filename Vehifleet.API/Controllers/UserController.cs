using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;
using Vehifleet.Services.UserService;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IEmployeeRepository employeeRepository,
                              IUserService userService,
                              IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.userService = userService;
            this.mapper = mapper;
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
                return Ok(mapper.Map<EmployeeDto>(employee));
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
        {
            var employee = await userService.Login(credentials);
            if (employee != null)
            {
                return Ok(mapper.Map<EmployeeDto>(employee));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("register")]
        // Used for tests.
        public async Task<IActionResult> Register([FromBody] EmployeeRegisterDto dto)
        {
            var identity = mapper.Map<EmployeeIdentity>(dto);

            if (await userService.CreateUser(identity, dto.Password))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}