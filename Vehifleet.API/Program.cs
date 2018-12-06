using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vehifleet.Data.DbAccess;

namespace Vehifleet.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);            

            //using (var scope = host.Services.CreateScope())
            //{
            //    try
            //    {                    
            //        var context = scope.ServiceProvider.GetService<VehifleetContext>();
            //        var configuration = scope.ServiceProvider.GetService<IConfiguration>();                    
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
            //        logger.LogError(ex, "Exception occured during database migration or seeding.");
            //    }
            //}

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .UseStartup<Startup>()
                          .ConfigureLogging((context, logging) =>
                                            {
                                                logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                                                logging.AddConsole();
                                                logging.AddDebug();
                                                logging.AddEventSourceLogger();
                                            })
                          .Build();
        }
    }
}