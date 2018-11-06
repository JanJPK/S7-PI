using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vehifleet.API.DbAccess;
using Vehifleet.API.DbAccess.Repositories;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;

namespace Vehifleet.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(setupAction => { setupAction.ReturnHttpNotAcceptable = true; })
                    .AddJsonOptions(jsonOptions =>
                     {
                         jsonOptions.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                         jsonOptions.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                     });

            services.AddCors(cors =>
            {
                cors.AddPolicy("AllowAllOriginsHeadersAndMethods",
                               builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });

            var dbConnectionString = Configuration["ConnectionStrings:VehifleetDb"];
            services.AddDbContext<VehifleetContext>(c => c.UseSqlServer(dbConnectionString));

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected error has occured.");
                    });
                });
            }

            ConfigureAutoMapper();
            app.UseCors("AllowAllOriginsHeadersAndMethods");
            app.UseMvc();
        }

        private void ConfigureAutoMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Vehicle, VehicleDto>()
                      .ForMember(d => d.VehicleName,
                                 m => m.MapFrom(s => s.VehicleSpecification.Name));
            });
        }
    }
}