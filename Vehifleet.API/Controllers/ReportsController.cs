using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Vehifleet.Services.CsvService;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api/reports")]
    [Authorize(Policy = "RequireElevatedRights")]
    public class ReportsController : ControllerBase
    {
        private readonly ICsvService csvService;
        private readonly IConfiguration configuration;       

        public ReportsController(ICsvService csvService, 
                                 IConfiguration configuration)
        {
            this.csvService = csvService;
            this.configuration = configuration;
        }

        [HttpPost("generate/{days}")]
        public async Task<IActionResult> Generate(int days)
        {
            if (days < 0)
            {
                days = Convert.ToInt32(configuration["Reports:Dir"]);
            }
            await csvService.GenerateReports(configuration["Reports:Dir"], days);
            return Ok("Report generated.");
        }
    }
}