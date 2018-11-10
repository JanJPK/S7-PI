using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehifleet.API.Repositories;
using Vehifleet.API.Repositories.Interfaces;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;

namespace Vehifleet.API.Controllers
{
    [Route("api/bookings")]
    public class BookingController : Controller
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IEmployeeRepository employeeRepository;

        public BookingController(IBookingRepository bookingRepository,
                                 IEmployeeRepository employeeRepository)
        {
            this.bookingRepository = bookingRepository;
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("employee/{id}")]
        public async Task<IActionResult> GetBookingsListByEmployeeId(int id)
        {
            bool employeeExists = await employeeRepository.CheckIfEmployeeExists(id);
            if (employeeExists)
            {
                var bookings = await bookingRepository.GetByEmployeeId(id);

                return Ok(Mapper.Map<IEnumerable<Booking>, BookingListDto>(bookings));
            }
            else
            {
                return BadRequest($"Invalid employee id [{id}].");
            }
        }
    }
}