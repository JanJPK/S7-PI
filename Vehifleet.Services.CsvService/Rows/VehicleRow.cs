using Vehifleet.Data.Models;

namespace Vehifleet.Services.CsvService.Rows
{
    public class VehicleRow
    {
        public string ChassisCode { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string YearOfManufacture { get; set; }

        public decimal Cost { get; set; }

        public int Mileage { get; set; }

        public int FuelConsumed { get; set; }

        public VehicleRow(Vehicle vehicle)
        {
            ChassisCode = vehicle.ChassisCode;
            Manufacturer = vehicle.VehicleModel.Manufacturer;
            Model = vehicle.VehicleModel.Model;
            YearOfManufacture = vehicle.YearOfManufacture.ToString();
            Cost = vehicle.Cost;
            Mileage = vehicle.Mileage;
            FuelConsumed = vehicle.FuelConsumed;
        }
    }
}