using System.Linq;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Services.CsvService.Rows
{
    public class EmployeeRow
    {
        public string EmployeeUserName { get; set; }

        public int BookingsCount { get; set; }

        public decimal Cost { get; set; }

        public int Mileage { get; set; }

        public int FuelConsumed { get; set; }

        public EmployeeRow(Employee employee)
        {
            EmployeeUserName = employee.Identity.UserName;
            BookingsCount = employee.Bookings.Count(b => b.Status == BookingStatus.Completed);
            Cost = employee.Cost;
            Mileage = employee.Mileage;
            FuelConsumed = employee.FuelConsumed;
        }
    }
}