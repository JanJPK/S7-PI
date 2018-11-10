using System;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vehifleet.API.DbAccess;
using Vehifleet.API.Repositories;
using Vehifleet.API.Repositories.Interfaces;
using Vehifleet.API.Security;
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

            // Security
            services.AddCors(cors =>
            {
                cors.AddPolicy("AllowAllOriginsHeadersAndMethods",
                               builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });

            services.AddIdentityCore<EmployeeIdentity>(options => { options.User.RequireUniqueEmail = true; })
                    .AddEntityFrameworkStores<VehifleetContext>()
                    .AddDefaultTokenProviders();

            // Jwt
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]));
            services.Configure<JwtOptions>(options =>
            {
                options.Issuer = Configuration["Jwt:Issuer"];
                options.Audience = Configuration["Jwt:Audience"];
                options.SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.ClaimsIssuer = Configuration["Jwt:Issuer"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                options.SaveToken = true;
            });

            services.AddAuthorization(options =>
            {
                options
                   .AddPolicy("ApiUser", policy => policy.RequireClaim("rol", "api_access"));
            });

            // Services
            services.AddDbContext<VehifleetContext>(c => c.UseSqlServer(Configuration["ConnectionStrings:VehifleetDb"]));
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IInspectionRepository, InspectionRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IJwtManager, JwtManager>();
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
            app.UseAuthentication();
            app.UseMvc();
        }

        private void ConfigureAutoMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Vehicle, VehicleDto>()
                      .ForMember(d => d.Manufacturer,
                                 m => m.MapFrom(s => s.VehicleSpecification.Manufacturer))
                      .ForMember(d => d.Model,
                                 m => m.MapFrom(s => s.VehicleSpecification.Model))
                      .ForMember(d => d.InsuranceExpirationDate,
                                 m => m.MapFrom(s => s.Insurances.Last().ExpirationDate))
                      .ForMember(d => d.InspectionExpirationDate,
                                 m => m.MapFrom(s => s.Inspections.Last().ExpirationDate));
                config.CreateMap<Vehicle, VehicleListItemDto>()
                      .ForMember(d => d.Manufacturer,
                                 m => m.MapFrom(s => s.VehicleSpecification.Manufacturer))
                      .ForMember(d => d.Model,
                                 m => m.MapFrom(s => s.VehicleSpecification.Model))
                      .ForMember(d => d.Horsepower,
                                 m => m.MapFrom(s => s.VehicleSpecification.Horsepower))
                      .ForMember(d => d.Seats,
                                 m => m.MapFrom(s => s.VehicleSpecification.Seats))
                      .ForMember(d => d.CanBeBookedUntil,
                                 o => o.MapFrom(s => s.CanBeBookedUntil));
                config.CreateMap<EmployeeRegistrationDto, EmployeeIdentity>();
            });
        }
    }
}