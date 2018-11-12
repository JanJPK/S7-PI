using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vehifleet.API.QueryFilters;
using Vehifleet.Data.Dtos;
using Vehifleet.Services;
using Vehifleet.Services.Interfaces;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    //[Authorize(Policy = "RequireEmployeeRole")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] VehicleFilter filter)
        {
            var vehicles = await vehicleService.Get(filter);

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

            var vehicles = await vehicleService.Get(filter);

            return Ok(Mapper.Map<IEnumerable<VehicleListItemDto>>(vehicles));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var vehicle = await vehicleService.GetById(id);
        
            if (vehicle == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(Mapper.Map<VehicleDto>(vehicle));
            }
        }

        //
        //[HttpGet("bookable")]
        //public async Task<IActionResult> GetBookableVehiclesList()
        //{
        //    var vehicles = await vehicleRepository.Get();
        //    var bookableVehicles = vehicles.Where(v => v.Insurances.Last().ExpirationDate > DateTime.Today &&
        //                                               v.Inspections.Last().ExpirationDate > DateTime.Today &&
        //                                               v.Status == VehicleStatus.Available);
        //
        //    return Ok(Mapper.Map<IEnumerable<VehicleListItemDto>>(bookableVehicles));
        //}
    }
}