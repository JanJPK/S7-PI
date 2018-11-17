using System;
using System.Linq;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Repositories;
using Vehifleet.Repositories.Interfaces;
using Vehifleet.Services;
using Vehifleet.Services.Helper;
using Vehifleet.Services.Interfaces;

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
                     })
                    .AddFluentValidation(o => o.RegisterValidatorsFromAssemblyContaining<BookingDto>());

            // Security
            services.AddCors(o =>
            {
                o.AddPolicy("AllowAllOriginsHeadersAndMethods",
                               builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });

            services.AddIdentityCore<EmployeeUser>(options => { options.User.RequireUniqueEmail = true; })
                    .AddEntityFrameworkStores<VehifleetContext>()
                    .AddDefaultTokenProviders();

            // Jwt
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]));
            services.Configure<JwtOptions>(o =>
            {
                o.Issuer = Configuration["Jwt:Issuer"];
                o.Audience = Configuration["Jwt:Audience"];
                o.SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            });

            // Authentication
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.ClaimsIssuer = Configuration["Jwt:Issuer"];
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,

                    ValidateLifetime = true,                    
                    RequireExpirationTime = false,
                    ClockSkew = TimeSpan.Zero
                };
                o.SaveToken = true;
            });

            services.AddAuthorization(o =>
            {                
                o.AddPolicy("RequireEmployeeRole", p => p.RequireRole("Employee"));
                o.AddPolicy("requireElevatedRights", p => p.RequireRole("Administrator", "Manager"));
                //o.AddPolicy("ApiUser", policy => policy.RequireClaim("rol", "api_access"));
            });

            // Services
            services.AddDbContext<VehifleetContext>(c => c.UseSqlServer(Configuration["ConnectionStrings:VehifleetDb"]));
            services.AddScoped<IGenericRepository<Booking, int>, BookingRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IGenericRepository<EmployeeUser, string>, IdentityRepository>();
            services.AddScoped<IGenericRepository<Inspection, int>, InspectionRepository>();
            services.AddScoped<IGenericRepository<Insurance, int>, InsuranceRepository>();
            services.AddScoped<IGenericRepository<Location, string>, LocationRepository>();
            services.AddScoped<IGenericRepository<Maintenance, int>, MaintenanceRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IGenericRepository<Vehicle, int>, VehicleRepository>();
            services.AddScoped<IGenericRepository<VehicleSpecification, int>, VehicleSpecificationRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAuditService, UserAuditService>();
            services.AddScoped<IStatusService, StatusService>();
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
            app.UseAuthentication();
            app.UseMvc();
        }

        private void ConfigureAutoMapper()
        {
            Mapper.Initialize(config =>
            {
                //config.CreateMap<Vehicle, VehicleDto>()
                //      .ForMember(d => d.Manufacturer,
                //                 m => m.MapFrom(s => s.VehicleSpecification.Manufacturer))
                //      .ForMember(d => d.Model,
                //                 m => m.MapFrom(s => s.VehicleSpecification.Model))
                //      .ForMember(d => d.Horsepower,
                //                 m => m.MapFrom(s =>s.VehicleSpecification.Horsepower))
                //      .ForMember(d => d.Seats,
                //                 m => m.MapFrom(s => s.VehicleSpecification.Seats))
                //      .ForMember(d => d.InsuranceExpirationDate,
                //                 m => m.MapFrom(s => s.CurrentInsurance.ExpirationDate))
                //      .ForMember(d => d.InspectionExpirationDate,
                //                 m => m.MapFrom(s => s.CurrentInspection.ExpirationDate));
                //config.CreateMap<Vehicle, VehicleListItemDto>()
                //      .ForMember(d => d.Manufacturer,
                //                 m => m.MapFrom(s => s.VehicleSpecification.Manufacturer))
                //      .ForMember(d => d.Model,
                //                 m => m.MapFrom(s => s.VehicleSpecification.Model))
                //      .ForMember(d => d.Horsepower,
                //                 m => m.MapFrom(s => s.VehicleSpecification.Horsepower))
                //      .ForMember(d => d.Seats,
                //                 m => m.MapFrom(s => s.VehicleSpecification.Seats))
                //      .ForMember(d => d.CanBeBookedUntil,
                //                 o => o.MapFrom(s => s.CanBeBookedUntil));
                config.CreateMap<EmployeeRegisterDto, EmployeeUser>();
                config.CreateMap<Employee, EmployeeLoginDto>()
                      .ForMember(d => d.UserName,
                                 m => m.MapFrom(s => s.Identity.UserName))
                      .ForMember(d => d.FirstName,
                                 m => m.MapFrom(s => s.Identity.FirstName))
                      .ForMember(d => d.LastName,
                                 m => m.MapFrom(s => s.Identity.LastName))
                      .ForMember(d => d.Department,
                                 m => m.MapFrom(s => s.Identity.Department));
                config.CreateMap<BookingDto, Booking>()
                      .ForMember(d => d.Employee, o => o.Ignore())
                      .ForMember(d => d.Manager, o => o.Ignore())
                      .ForMember(d => d.Vehicle, o => o.Ignore())
                      .ForMember(d => d.AddedOn, o => o.Ignore())
                      .ForMember(d => d.AddedBy, o => o.Ignore())
                      .ForMember(d => d.ModifiedOn, o => o.Ignore())
                      .ForMember(d => d.ModifiedBy, o => o.Ignore());

            });
        }
    }
}