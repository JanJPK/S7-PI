using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api/maintenances")]
    //[Authorize(Policy = "RequireEmployeeRole")]
    public class MaintenanceController : ControllerBase
    {
        private readonly IGenericRepository<Maintenance, int> maintenanceRepository;
        private readonly IGenericRepository<Vehicle, int> vehicleRepository;
        private readonly IMapper mapper;

        public MaintenanceController(IGenericRepository<Maintenance, int> maintenanceRepository,
                                     IGenericRepository<Vehicle, int> vehicleRepository,
                                     IMapper mapper)
        {
            this.maintenanceRepository = maintenanceRepository;
            this.vehicleRepository = vehicleRepository;
            this.mapper = mapper;
        }

        [HttpGet("vehicle/{id}")]
        public async Task<IActionResult> GetByVehicleId(int id)
        {
            if (!await vehicleRepository.Exists(id))
            {
                return NotFound("No such vehicle.");
            }

            var query = maintenanceRepository.Get().Where(m => m.VehicleId == id);

            var maintenances = await query.ToListAsync();

            return Ok(mapper.Map<IEnumerable<MaintenanceDto>>(maintenances));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var maintenance = await maintenanceRepository.GetById(id);

            if (maintenance == null)
            {
                return NotFound("No such maintenance.");
            }
            else
            {
                return Ok(mapper.Map<MaintenanceDto>(maintenance));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaintenanceDto maintenanceDto)
        {
            var maintenance = mapper.Map<Maintenance>(maintenanceDto);
            await maintenanceRepository.Insert(maintenance);
            return Ok(maintenance.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MaintenanceDto maintenanceDto)
        {
            if (!await maintenanceRepository.Exists(id))
            {
                return NotFound("No such maintenance.");
            }

            var maintenance = mapper.Map<Maintenance>(maintenanceDto);
            await maintenanceRepository.Update(maintenance);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await maintenanceRepository.Exists(id))
            {
                return NotFound("No such maintenance.");
            }

            await maintenanceRepository.Delete(id);
            return Ok();
        }
    }
}