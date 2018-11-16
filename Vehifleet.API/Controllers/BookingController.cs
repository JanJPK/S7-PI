using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehifleet.API.QueryFilters;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Services;
using Vehifleet.Services.Interfaces;

namespace Vehifleet.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;
        private readonly IVehicleService vehicleService;

        public BookingController(IBookingService bookingService,
                                 IVehicleService vehicleService)
        {
            this.bookingService = bookingService;
            this.vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BookingFilter filter)
        {
            var bookings = await bookingService.Get(filter);

            return Ok(Mapper.Map<IEnumerable<BookingListDto>>(bookings));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var booking = await bookingService.GetById(id);

            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<VehicleDto>(booking));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookingDto bookingDto)
        {            
            try
            {
                var booking = Mapper.Map<Booking>(bookingDto);
                var vehicle = 
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}