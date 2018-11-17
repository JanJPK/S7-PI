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
    [Route("api/vehicles")]
    //[Authorize(Policy = "RequireEmployeeRole")]
    public class VehicleController : ControllerBase
    {
        private readonly IGenericRepository<Vehicle, int> vehicleRepository;

        public VehicleController(IGenericRepository<Vehicle, int> vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] VehicleFilter filter)
        {
            var query = filter.Filter(vehicleRepository.Get());

            var vehicles = await query
                                .Include(v => v.VehicleSpecification)
                                .Include(v => v.Insurances)
                                .Include(v => v.Inspections)
                                .Include(v => v.Location)
                                .ToListAsync();

            return Ok(Mapper.Map<IEnumerable<VehicleListItemDto>>(vehicles));
        }

        [HttpGet("bookable")]
        public async Task<IActionResult> GetBookable()
        {
            VehicleFilter filter = new VehicleFilter
            {
                Status = "Available",
                MinBookingDays = 1
            };

            var query = filter.Filter(vehicleRepository.Get());

            var vehicles = await query
                                .Include(v => v.VehicleSpecification)
                                .Include(v => v.Insurances)
                                .Include(v => v.Inspections)
                                .Include(v => v.Location)
                                .ToListAsync();

            return Ok(Mapper.Map<IEnumerable<VehicleListItemDto>>(vehicles));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid Id.");
            }

            var vehicle = await vehicleRepository.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<VehicleDto>(vehicle));
            }
        }
    }
}