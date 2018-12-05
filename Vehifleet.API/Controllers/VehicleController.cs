using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehifleet.API.QueryFilters;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    //[Authorize(Policy = "RequireEmployeeRole")]
    public class VehicleController : ControllerBase
    {
        private readonly IGenericRepository<Vehicle, int> vehicleRepository;
        private readonly IGenericRepository<VehicleModel, int> vehicleModelRepository;
        private readonly IGenericRepository<Booking, int> bookingRepository;
        private readonly IMapper mapper;

        public VehicleController(IGenericRepository<Vehicle, int> vehicleRepository,
                                 IGenericRepository<VehicleModel, int> vehicleModelRepository,
                                 IGenericRepository<Booking, int> bookingRepository,
                                 IMapper mapper)
        {
            this.vehicleRepository = vehicleRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] VehicleFilter filter)
        {
            var query = filter.Filter(vehicleRepository.Get());

            var vehicles = await query
                                .Include(v => v.VehicleModel)
                                .Include(v => v.Location)
                                .ToListAsync();

            return Ok(mapper.Map<IEnumerable<VehicleListItemDto>>(vehicles));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicle = await vehicleRepository.GetById(id);

            if (vehicle == null)
            {
                return NotFound("No such vehicle.");
            }
            else
            {
                var dto = mapper.Map<VehicleDto>(vehicle);
                dto.HasBookings = await bookingRepository.Get()
                                                   .Where(b => b.VehicleId == id)
                                                   .AnyAsync();

                return Ok(dto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehicleDto vehicleDto)
        {
            if (!await vehicleModelRepository.Exists(vehicleDto.VehicleModelId))
            {
                return NotFound("No such vehicle model.");
            }

            var vehicle = mapper.Map<Vehicle>(vehicleDto);
            await vehicleRepository.Insert(vehicle);
            return Ok(vehicle.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VehicleDto vehicleDto)
        {
            if (!await vehicleRepository.Exists(id))
            {
                return NotFound("No such vehicle model.");
            }

            var vehicle = mapper.Map<Vehicle>(vehicleDto);
            await vehicleRepository.Update(vehicle);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await vehicleRepository.GetById(id);
            if (vehicle == null)
            {
                return NotFound("No such vehicle.");
            }

            bool hasBookings = await bookingRepository.Get().Where(b => b.VehicleId == id).AnyAsync();
            if (hasBookings)
            {
                return BadRequest("Vehicle has bookings.");
            }

            await vehicleRepository.Delete(vehicle);
            return Ok();
        }
    }
}