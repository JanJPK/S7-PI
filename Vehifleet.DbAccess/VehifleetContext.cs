using Microsoft.EntityFrameworkCore;
using Vehifleet.Model;

namespace Vehifleet.DbAccess
{
    public class VehifleetContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UsageReport> UsageReports { get; set; }
        public DbSet<Employee> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleSpecification> VehicleSpecifications { get; set; }

        public VehifleetContext() : base()
        {            
        }

        public VehifleetContext(DbContextOptions<VehifleetContext> options) : base(options)
        {
        }
    }
}