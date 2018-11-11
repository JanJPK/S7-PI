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
    [Authorize(Policy = "RequireEmployeeRole")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }


        [HttpGet]
        public async Task<IActionResult> GetVehicles([FromQuery] VehicleFilter filter)
        {
            var vehicles = await vehicleService.Get(filter);

            return Ok(Mapper.Map<IEnumerable<VehicleListItemDto>>(vehicles));
        }

        //[HttpGet("{id}", Name = nameof(GetVehicleById))]
        //public async Task<IActionResult> GetVehicleById(int id)
        //{
        //    var vehicle = await vehicleRepository.GetById(id);
        //
        //    if (vehicle == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        return Ok(Mapper.Map<VehicleDto>(vehicle));
        //    }
        //}
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