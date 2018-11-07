using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehifleet.API.Repositories.Interfaces;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.API.Controllers
{
    [Route("api/vehicles")]
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await vehicleRepository.Get();

            return Ok(Mapper.Map<IEnumerable<VehicleDto>>(vehicles));
        }

        [HttpGet("bookable")]
        public async Task<IActionResult> GetBookableVehiclesList()
        {
            var vehicles = await vehicleRepository.Get();
            var bookableVehicles = vehicles.Where(v => v.Insurances.Last().ExpirationDate > DateTime.Today &&
                                                       v.Inspections.Last().ExpirationDate > DateTime.Today &&
                                                       v.Status == VehicleStatus.Available);

            return Ok(Mapper.Map<IEnumerable<VehicleListDto>>(bookableVehicles));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetVehiclesByStatus(string status)
        {
            if (Enum.TryParse(status, true, out VehicleStatus parsedStatus))
            {
                var vehicles = await vehicleRepository.GetByStatus(parsedStatus);
                return Ok(Mapper.Map<IEnumerable<VehicleDto>>(vehicles));
            }
            else
            {
                return BadRequest($"Status [{status}] is not a valid vehicle status.");
            }
        }

        [HttpGet("location/{locationCode}")]
        public async Task<IActionResult> GetVehiclesByLocation(string locationCode)
        {
            var vehicles = await vehicleRepository.GetByLocationCode(locationCode);

            return Ok(Mapper.Map<IEnumerable<VehicleDto>>(vehicles));
        }

        [HttpGet("{id}", Name = nameof(GetVehicleById))]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var vehicle = await vehicleRepository.GetById(id);

            if (vehicle == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(Mapper.Map<VehicleDto>(vehicle));
            }
        }
    }
}