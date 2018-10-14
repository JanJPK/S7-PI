using System;
using System.ComponentModel.DataAnnotations;
using Vehifleet.Model.Enums;

namespace Vehifleet.Model
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [Required]
        public EventType Type { get; set; }

        public int? BookingId { get; set; }
        public Booking Booking { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public bool IsCompleted { get; set; }
    }
}