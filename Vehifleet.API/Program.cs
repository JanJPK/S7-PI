using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vehifleet.API.DbAccess;

namespace Vehifleet.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                try
                {                    
                    var context = scope.ServiceProvider.GetService<VehifleetContext>();
                    context.CleanDatabase();
                    context.SeedDatabase();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
                    logger.LogError(ex, "Exception occured during database migration or seeding.");                    
                }
            }
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .UseStartup<Startup>()
                          .Build();
        }
    }
}