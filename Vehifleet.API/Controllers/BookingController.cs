using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehifleet.API.QueryFilters;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;
using Vehifleet.Helper.Extensions;
using Vehifleet.Repositories.Interfaces;
using Vehifleet.Services.Interfaces;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IGenericRepository<Booking, int> bookingRepository;
        private readonly IGenericRepository<Vehicle, int> vehicleRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IGenericRepository<VehicleModel, int> vehicleSpecificationRepository;
        private readonly IStatusService statusService;

        public BookingController(IGenericRepository<Booking, int> bookingRepository,
                                 IGenericRepository<Vehicle, int> vehicleRepository,
                                 IEmployeeRepository employeeRepository,
                                 IGenericRepository<VehicleModel, int> vehicleSpecificationRepository,
                                 IStatusService statusService)
        {
            this.bookingRepository = bookingRepository;
            this.vehicleRepository = vehicleRepository;
            this.employeeRepository = employeeRepository;
            this.vehicleSpecificationRepository = vehicleSpecificationRepository;
            this.statusService = statusService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BookingFilter filter)
        {
            var query = bookingRepository.Get()
                                         .Include(b => b.Vehicle)
                                         .ThenInclude(v => v.VehicleModel)
                                         .Include(b => b.Employee)
                                         .ThenInclude(e => e.Identity);

            var bookings = await filter.Filter(query)
                                       .ToListAsync();

            return Ok(Mapper.Map<IEnumerable<BookingListItemDto>>(bookings));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await bookingRepository.GetById(id);

            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<BookingDto>(booking));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookingDto bookingDto)
        {
            if (!await vehicleRepository.Exists(bookingDto.VehicleId))
            {
                return NotFound("No such vehicle.");
            }

            if (!await employeeRepository.Exists(bookingDto.EmployeeId))
            {
                return NotFound("No such employee.");
            }

            var booking = Mapper.Map<Booking>(bookingDto);
            var vehicle = await vehicleRepository.GetById(booking.VehicleId);
            vehicle.Status = VehicleStatus.Available;
            await bookingRepository.Insert(booking);
            await vehicleRepository.Update(vehicle);
            return Ok(booking.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookingDto bookingDto)
        {
            var oldBooking = await bookingRepository.GetById(id);
            if (oldBooking == null)
            {
                return NotFound();
            }

            if (oldBooking.Status == BookingStatus.Completed)
            {
                return BadRequest("Cannot update completed bookings.");
            }

            var booking = Mapper.Map<Booking>(bookingDto);
            if (booking.Status == BookingStatus.Completed)
            {
                var vehicle = await vehicleRepository.GetById(booking.VehicleId);
                var vehicleSpecification = await vehicleSpecificationRepository.GetById(vehicle.VehicleModelId);
                var employee = await employeeRepository.GetById(booking.EmployeeId);
                vehicleSpecification.AddGeneratedCosts(booking);
                vehicle.AddGeneratedCosts(booking);
                employee.AddGeneratedCosts(booking);
                vehicle.Status = VehicleStatus.Available;
                await vehicleRepository.Update(vehicle);
                await vehicleSpecificationRepository.Update(vehicleSpecification);
                await employeeRepository.Update(employee);
                await bookingRepository.Update(booking);
            }
            else
            {
                await bookingRepository.Update(booking);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await bookingRepository.GetById(id);
            if (booking == null)
            {
                return NotFound();
            }

            if (booking.Status != BookingStatus.Created)
            {
                return BadRequest("Cannot delete bookings that have been submitted");
            }

            var vehicle = await vehicleRepository.GetById(booking.VehicleId);
            vehicle.Status = VehicleStatus.Available;
            await bookingRepository.Delete(id);
            await vehicleRepository.Update(vehicle);
            return Ok();
        }
    }
}