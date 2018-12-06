using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api/locations")]
    [Authorize(Policy = "RequireEmployeeRole")]
    public class LocationController : ControllerBase
    {
        private readonly IGenericRepository<Location, string> locationRepository;

        public LocationController(IGenericRepository<Location, string> locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = locationRepository.Get();            
            var locations = await query.Select(l => l.LocationCode).ToListAsync();

            return Ok(locations);
        }
        
    }
}