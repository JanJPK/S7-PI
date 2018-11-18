using System;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Data.Dtos
{
    public class BookingListItemDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeUserName { get; set; }

        public string Vehicle { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}