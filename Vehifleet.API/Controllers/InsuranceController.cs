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
    [Route("api/insurances")]
    [Authorize(Policy = "RequireElevatedRights")]
    public class InsuranceController : ControllerBase
    {
        private readonly IGenericRepository<Insurance, int> insuranceRepository;
        private readonly IGenericRepository<Vehicle, int> vehicleRepository;
        private readonly IMapper mapper;

        public InsuranceController(IGenericRepository<Insurance, int> insuranceRepository,
                                   IGenericRepository<Vehicle, int> vehicleRepository, 
                                   IMapper mapper)
        {
            this.insuranceRepository = insuranceRepository;
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

            var query = insuranceRepository.Get().Where(m => m.VehicleId == id);

            var insurances = await query.ToListAsync();

            return Ok(mapper.Map<IEnumerable<InsuranceDto>>(insurances));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var insurance = await insuranceRepository.GetById(id);

            if (insurance == null)
            {
                return NotFound("No such insurance.");
            }
            else
            {
                return Ok(mapper.Map<InsuranceDto>(insurance));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InsuranceDto insuranceDto)
        {
            var insurance = mapper.Map<Insurance>(insuranceDto);
            await insuranceRepository.Insert(insurance);

            var vehicle = await vehicleRepository.GetById(insurance.VehicleId);
            vehicle.Cost += insurance.Cost;
            vehicle.AdjustCanBeBookedUntil(insurance.EndDate);
            await vehicleRepository.Update(vehicle);

            return Ok(insurance.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InsuranceDto insuranceDto)
        {
            var oldInsurance = await insuranceRepository.GetById(id);
            if (oldInsurance == null)
            {
                return NotFound("No such insurance.");
            }

            var insurance = mapper.Map<Insurance>(insuranceDto);
            await insuranceRepository.Update(insurance);

            var vehicle = await vehicleRepository.GetById(insurance.VehicleId);
            var deltaCost = insurance.Cost - oldInsurance.Cost;
            vehicle.Cost += deltaCost;
            vehicle.AdjustCanBeBookedUntil(insurance.EndDate);
            await vehicleRepository.Update(vehicle);            

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await insuranceRepository.Exists(id))
            {
                return NotFound("No such insurance.");
            }

            await insuranceRepository.Delete(id);
            return Ok();
        }
    }
}