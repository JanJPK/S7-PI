using System;
using System.ComponentModel.DataAnnotations;
using Vehifleet.Model.Enums;

namespace Vehifleet.Model
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public Employee Manager { get; set; }

        [Required]
        public BookingStatus Status { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public Location StartLocation { get; set; }

        public Location EndLocation { get; set; }

        public int? UsageReportId { get; set; }

        public UsageReport UsageReport { get; set; }

        public string Notes { get; set; }
    }
}