using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vehifleet.Services.CsvService;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly ICsvService csvService;

        public ReportsController(ICsvService csvService)
        {
            this.csvService = csvService;
        }

        [HttpPost("generate/{days}")]
        public async Task<IActionResult> Generate(int days)
        {
            await csvService.GenerateReports(days);
            return Ok("Report generated.");
        }
    }
}