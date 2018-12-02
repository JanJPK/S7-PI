using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehifleet.API.QueryFilters;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api/vehicle-models")]
    //[Authorize(Policy = "RequireEmployeeRole")]
    public class VehicleModelController : ControllerBase
    {
        private readonly IGenericRepository<VehicleModel, int> vehicleModelRepository;
        private readonly IGenericRepository<Vehicle, int> vehicleRepository;

        public VehicleModelController(IGenericRepository<VehicleModel, int> vehicleModelRepository,
                                      IGenericRepository<Vehicle, int> vehicleRepository)
        {
            this.vehicleModelRepository = vehicleModelRepository;
            this.vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] VehicleModelFilter filter)
        {
            var query = filter.Filter(vehicleModelRepository.Get());

            var vehicleModels = await query.ToListAsync();

            return Ok(Mapper.Map<IEnumerable<VehicleModelDto>>(vehicleModels));
        }

        [HttpGet("manufacturers")]
        public async Task<IActionResult> GetManufacturers()
        {
            var query = vehicleModelRepository.Get();

            var manufacturers = await query
                                     .Select(vm => vm.Manufacturer)
                                     .Distinct()
                                     .ToListAsync();

            return Ok(manufacturers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicleModel = await vehicleModelRepository.GetById(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }
            else
            {
                var dto = Mapper.Map<VehicleModelDto>(vehicleModel);
                dto.HasVehicles = await vehicleRepository.Get()
                                                         .Where(v => v.VehicleModel.Id == id)
                                                         .AnyAsync();
                return Ok(dto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehicleModelDto vehicleModelDto)
        {
            var vehicleModel = Mapper.Map<VehicleModel>(vehicleModelDto);
            await vehicleModelRepository.Insert(vehicleModel);
            return Ok(vehicleModel.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VehicleModelDto vehicleModelDto)
        {
            var vehicle = Mapper.Map<VehicleModel>(vehicleModelDto);
            await vehicleModelRepository.Insert(vehicle);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await vehicleModelRepository.Exists(id))
            {
                return NotFound("No such vehicle model.");
            }

            bool hasVehicles = await vehicleRepository.Get().Where(v => v.VehicleModelId == id).AnyAsync();
            if (hasVehicles)
            {
                return BadRequest("Vehicle model has vehicles.");
            }

            await vehicleModelRepository.Delete(id);
            return Ok();
        }
    }
}