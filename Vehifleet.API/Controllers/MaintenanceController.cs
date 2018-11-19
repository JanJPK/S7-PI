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

        public MaintenanceController(IGenericRepository<Maintenance, int> maintenanceRepository,
                                     IGenericRepository<Vehicle, int> vehicleRepository)
        {
            this.maintenanceRepository = maintenanceRepository;
            this.vehicleRepository = vehicleRepository;
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

            return Ok(Mapper.Map<IEnumerable<MaintenanceDto>>(maintenances));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var maintenance = await maintenanceRepository.GetById(id);

            if (maintenance == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<MaintenanceDto>(maintenance));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaintenanceDto maintenanceDto)
        {
            var maintenance = Mapper.Map<Maintenance>(maintenanceDto);
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

            var maintenance = Mapper.Map<Maintenance>(maintenanceDto);
            await maintenanceRepository.Insert(maintenance);
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