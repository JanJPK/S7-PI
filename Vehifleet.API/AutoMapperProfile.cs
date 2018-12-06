using AutoMapper;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Dtos.BaseDtos;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.BaseEntities;
using Vehifleet.Helper.Extensions;

namespace Vehifleet.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AuditableEntity, AuditableDto>();
            CreateMap<CostGeneratingEntity, CostGeneratingDto>()
               .IncludeBase<AuditableEntity, AuditableDto>();

            CreateMap<Vehicle, VehicleDto>()
               .ForMember(d => d.Status,
                          m => m.MapFrom(d => d.Status.ToString().AddSpaces()))
               .ForMember(d => d.Engine,
                          m => m.MapFrom(s => s.VehicleModel.Engine))
               .ForMember(d => d.Horsepower,
                          m => m.MapFrom(s => s.VehicleModel.Horsepower))
               .ForMember(d => d.Seats,
                          m => m.MapFrom(s => s.VehicleModel.Seats))
               .ForMember(d => d.Manufacturer,
                          m => m.MapFrom(s => s.VehicleModel.Manufacturer))
               .ForMember(d => d.Model,
                          m => m.MapFrom(s => s.VehicleModel.Model));
            CreateMap<VehicleDto, Vehicle>()
               .ForMember(d => d.Status,
                          m => m.MapFrom(s => s.Status.RemoveSpaces()))
               .ForMember(d => d.Bookings, m => m.Ignore())
               .ForMember(d => d.Insurances, m => m.Ignore())
               .ForMember(d => d.Maintenances, m => m.Ignore())
               .ForMember(d => d.Location, m => m.Ignore())
               .ForMember(d => d.VehicleModel, m => m.Ignore());
            CreateMap<Vehicle, VehicleListItemDto>()
               .ForMember(d => d.Manufacturer,
                          m => m.MapFrom(s => s.VehicleModel.Manufacturer))
               .ForMember(d => d.Model,
                          m => m.MapFrom(s => s.VehicleModel.Model))
               .ForMember(d => d.Horsepower,
                          m => m.MapFrom(s => s.VehicleModel.Horsepower))
               .ForMember(d => d.Seats,
                          m => m.MapFrom(s => s.VehicleModel.Seats));

            CreateMap<Booking, BookingDto>();
            CreateMap<BookingDto, Booking>()
               .ForMember(d => d.Employee, o => o.Ignore())
               .ForMember(d => d.Vehicle, o => o.Ignore());
            CreateMap<Booking, BookingListItemDto>()
               .ForMember(d => d.Vehicle,
                          m => m.MapFrom(s => s.Vehicle.VehicleModel.Name))
               .ForMember(d => d.EmployeeUserName,
                          m => m.MapFrom(s => s.Employee.Identity.UserName))
               .ForMember(d => d.Status,
                          m => m.MapFrom(s => s.Status.ToString()));

            CreateMap<VehicleModel, VehicleModelDto>();
            CreateMap<VehicleModelDto, VehicleModel>()
               .ForMember(d => d.Vehicles, m => m.Ignore());

            CreateMap<Insurance, InsuranceDto>();
            CreateMap<InsuranceDto, Insurance>()
               .ForMember(d => d.Vehicle, m => m.Ignore());

            CreateMap<Maintenance, MaintenanceDto>();
            CreateMap<MaintenanceDto, Maintenance>()
               .ForMember(d => d.Vehicle, m => m.Ignore());

            CreateMap<EmployeeRegisterDto, EmployeeIdentity>();
            CreateMap<Employee, EmployeeDto>()
               .ForMember(d => d.UserName,
                          m => m.MapFrom(s => s.Identity.UserName))
               .ForMember(d => d.FirstName,
                          m => m.MapFrom(s => s.Identity.FirstName))
               .ForMember(d => d.LastName,
                          m => m.MapFrom(s => s.Identity.LastName))
               .ForMember(d => d.Department,
                          m => m.MapFrom(s => s.Identity.Department))
               .ForMember(d => d.Email,
                          m => m.MapFrom(s => s.Identity.Email))
               .ForMember(d => d.PhoneNumber,
                          m => m.MapFrom(s => s.Identity.PhoneNumber));
        }
    }
}