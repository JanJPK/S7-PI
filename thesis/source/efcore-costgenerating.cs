public abstract class CostGeneratingEntity : AuditableEntity
{
    [Required]
    public int Mileage { get; set; }

    [Required]
    public int FuelConsumed { get; set; }

    [Required]
    [Column(TypeName = "decimal(16, 2)")]
    public decimal Cost { get; set; }
}