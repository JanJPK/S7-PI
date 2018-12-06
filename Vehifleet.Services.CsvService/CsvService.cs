using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;
using Vehifleet.Repositories.Interfaces;
using Vehifleet.Services.CsvService.Rows;

namespace Vehifleet.Services.CsvService
{
    public class CsvService : ICsvService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IGenericRepository<Booking, int> bookingRepository;
        private readonly IGenericRepository<Vehicle, int> vehicleRepository;
        private readonly IGenericRepository<VehicleModel, int> vehicleModelRepository;

        public CsvService(IEmployeeRepository employeeRepository,
                          IGenericRepository<Booking, int> bookingRepository,
                          IGenericRepository<Vehicle, int> vehicleRepository,
                          IGenericRepository<VehicleModel, int> vehicleModelRepository)
        {
            this.employeeRepository = employeeRepository;
            this.bookingRepository = bookingRepository;
            this.vehicleRepository = vehicleRepository;
            this.vehicleModelRepository = vehicleModelRepository;
        }

        public async Task GenerateReports(string reportsDir, int bookingsHistoryDays = 30)
        {
            DateTime startDate = DateTime.UtcNow.Subtract(new TimeSpan(bookingsHistoryDays, 0, 0, 0)).Date;
            string dateStamp = DateTime.UtcNow
                                       .ToString(CultureInfo.InvariantCulture)
                                       .Replace(":", "-")
                                       .Replace(".", "-")
                                       .Replace("/", "-")
                                       .Replace(" ", "_");
            var employees = await employeeRepository.Get()
                                                    .Include(e => e.Identity)
                                                    .Include(e => e.Bookings)
                                                    .ToListAsync();
            var employeeRows = new List<EmployeeRow>();
            foreach (var employee in employees)
            {
                employeeRows.Add(new EmployeeRow(employee));
            }

            Write(employeeRows, $"{reportsDir}report_{dateStamp}_employees.csv");

            var bookings = await bookingRepository.Get()
                                                  .Where(b => b.Status == BookingStatus.Completed)
                                                  .Where(b => b.StartDate >= startDate)
                                                  .Include(b => b.Employee).ThenInclude(e => e.Identity)
                                                  .ToListAsync();
            var bookingRows = new List<BookingRow>();
            foreach (var booking in bookings)
            {
                bookingRows.Add(new BookingRow(booking));
            }

            Write(bookingRows, $"{reportsDir}report_{dateStamp}_bookings.csv");

            var vehicles = await vehicleRepository.Get()
                                                  .Include(v => v.VehicleModel)
                                                  .ToListAsync();
            var vehicleRows = new List<VehicleRow>();
            foreach (var vehicle in vehicles)
            {
                vehicleRows.Add(new VehicleRow(vehicle));
            }

            Write(vehicleRows, $"{reportsDir}report_{dateStamp}_vehicles.csv");

            var vehicleModels = await vehicleModelRepository.Get()
                                                            .ToListAsync();
            var vehicleModelRows = new List<VehicleModelRow>();
            foreach (var vehicleModel in vehicleModels)
            {
                vehicleModelRows.Add(new VehicleModelRow(vehicleModel));
            }

            Write(vehicleModelRows, $"{reportsDir}report_{dateStamp}_vehicle-models.csv");
        }

        private void Write<T>(IEnumerable<T> records, string filepath)
        {
            using (var tw = new StreamWriter(filepath, true, Encoding.UTF8))
            using (var csv = new CsvWriter(tw))
            {
                csv.WriteRecords(records);
            }
        }
    }
}