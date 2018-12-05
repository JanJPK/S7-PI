using Vehifleet.Data.Models;

namespace Vehifleet.Services.CsvService.Rows
{
    public class VehicleModelRow
    {
        public string ConfigurationCode { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }        

        public decimal Cost { get; set; }

        public int Mileage { get; set; }

        public int FuelConsumed { get; set; }

        public VehicleModelRow(VehicleModel vehicleModel)
        {
            ConfigurationCode = vehicleModel.ConfigurationCode;
            Manufacturer = vehicleModel.Manufacturer;
            Model = vehicleModel.Model;
            Cost = vehicleModel.Cost;
            Mileage = vehicleModel.Mileage;
            FuelConsumed = vehicleModel.FuelConsumed;
        }
    }
}