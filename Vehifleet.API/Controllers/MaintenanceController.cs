using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api/maintenances")]
    [Authorize(Policy = "RequireElevatedRights")]
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

            var vehicle = await vehicleRepository.GetById(maintenance.VehicleId);            
            vehicle.Cost += maintenance.Cost;
            await vehicleRepository.Update(vehicle);

            return Ok(maintenance.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MaintenanceDto maintenanceDto)
        {
            var oldMaintenance = await maintenanceRepository.GetById(id);
            if (oldMaintenance == null)
            {
                return NotFound("No such maintenance.");
            }

            var maintenance = mapper.Map<Maintenance>(maintenanceDto);
            await maintenanceRepository.Update(maintenance);

            var vehicle = await vehicleRepository.GetById(maintenance.VehicleId);
            var deltaCost = maintenance.Cost - oldMaintenance.Cost;
            vehicle.Cost += deltaCost;
            await vehicleRepository.Update(vehicle);

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