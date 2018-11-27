namespace Vehifleet.Data.Dtos.BaseDtos
{
    public abstract class CostGeneratingDto : AuditableDto
    {
        public int Mileage { get; set; }

        public int FuelConsumed { get; set; }

        public decimal Cost { get; set; }
    }
}