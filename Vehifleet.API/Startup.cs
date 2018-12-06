using System;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
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
using Vehifleet.Data.DbAccess;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Dtos.BaseDtos;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.BaseEntities;
using Vehifleet.Helper.Extensions;
using Vehifleet.Repositories;
using Vehifleet.Repositories.Interfaces;
using Vehifleet.Services;
using Vehifleet.Services.CsvService;
using Vehifleet.Services.UserService;

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

            services.AddIdentityCore<EmployeeIdentity>(options => { options.User.RequireUniqueEmail = true; })
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
                o.AddPolicy("RequireElevatedRights", p => p.RequireRole("Administrator", "Manager"));
            });

            // AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Services
            services.AddDbContext<VehifleetContext>(c => c.UseSqlServer(Configuration["ConnectionStrings:VehifleetDb"]));
            services.AddScoped<IGenericRepository<Booking, int>, BookingRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IGenericRepository<EmployeeIdentity, string>, IdentityRepository>();
            services.AddScoped<IGenericRepository<Insurance, int>, InsuranceRepository>();
            services.AddScoped<IGenericRepository<Location, string>, LocationRepository>();
            services.AddScoped<IGenericRepository<Maintenance, int>, MaintenanceRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IGenericRepository<Vehicle, int>, VehicleRepository>();
            services.AddScoped<IGenericRepository<VehicleModel, int>, VehicleModelRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAuditService, UserAuditService>();
            services.AddScoped<ICsvService, CsvService>();
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

            app.UseCors("AllowAllOriginsHeadersAndMethods");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}