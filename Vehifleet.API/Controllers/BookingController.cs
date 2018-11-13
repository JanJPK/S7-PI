using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vehifleet.Data.Dtos;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        public BookingController()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookingDto booking)
        {
            return Ok();
        }
    }
}