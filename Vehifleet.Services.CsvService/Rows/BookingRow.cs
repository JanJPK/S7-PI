using System.Globalization;
using Vehifleet.Data.Models;

namespace Vehifleet.Services.CsvService.Rows
{
    public class BookingRow
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string EmployeeUserName { get; set; }

        public decimal Cost { get; set; }

        public int Mileage { get; set; }

        public int FuelConsumed { get; set; }

        public BookingRow(Booking booking)
        {
            Id = booking.Id;
            Date = booking.StartDate.Date.ToString(CultureInfo.InvariantCulture);
            EmployeeUserName = booking.Employee.Identity.UserName;
            Cost = booking.Cost;
            Mileage = booking.Mileage;
            FuelConsumed = booking.FuelConsumed;
        }
    }
}