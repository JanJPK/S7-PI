using System;

namespace Vehifleet.Data.Dtos
{
    public class BookingUpdateDto
    {
        public int? Id { get; set; }

        public int? ManagerId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Notes { get; set; }

        public int? Mileage { get; set; }

        public int? FuelConsumed { get; set; }

        public decimal? Cost { get; set; }
    }
}