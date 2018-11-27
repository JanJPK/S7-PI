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
    [Route("api/insurances")]
    //[Authorize(Policy = "RequireEmployeeRole")]
    public class InsuranceController : ControllerBase
    {
        private readonly IGenericRepository<Insurance, int> insuranceRepository;
        private readonly IGenericRepository<Vehicle, int> vehicleRepository;

        public InsuranceController(IGenericRepository<Insurance, int> insuranceRepository,
                                   IGenericRepository<Vehicle, int> vehicleRepository)
        {
            this.insuranceRepository = insuranceRepository;
            this.vehicleRepository = vehicleRepository;
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

            return Ok(Mapper.Map<IEnumerable<InsuranceDto>>(insurances));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var insurance = await insuranceRepository.GetById(id);

            if (insurance == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<InsuranceDto>(insurance));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InsuranceDto insuranceDto)
        {
            var insurance = Mapper.Map<Insurance>(insuranceDto);
            await insuranceRepository.Insert(insurance);
            return Ok(insurance.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InsuranceDto insuranceDto)
        {
            if (!await insuranceRepository.Exists(id))
            {
                return NotFound("No such maintenance.");
            }

            var insurance = Mapper.Map<Insurance>(insuranceDto);
            await insuranceRepository.Update(insurance);
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