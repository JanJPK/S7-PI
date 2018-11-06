using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.DbAccess
{
    public class VehifleetContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleSpecification> VehicleSpecifications { get; set; }

        public VehifleetContext(DbContextOptions<VehifleetContext> options) : base(options)
        {
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var changedEntries = ChangeTracker.Entries()
                                              .Where(e => e.State == EntityState.Added
                                                       || e.State == EntityState.Modified);

            foreach (var entry in changedEntries)
            {
                var entity = entry.Entity as AuditableEntity;

                if (entry.State == EntityState.Added)
                {
                    entity.AddedBy = "admin";
                    entity.AddedOn = DateTime.UtcNow;
                }
                entity.UpdatedBy = "admin";
                entity.UpdatedOn = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Booking>()
            //            .HasOne(b => b.Employee)
            //            .WithMany(e => e.Bookings)
            //            .HasForeignKey(e => e.EmployeeId)
            //            .OnDelete(DeleteBehavior.Restrict);
            //
            //modelBuilder.Entity<Booking>()
            //            .HasOne(b => b.Manager)
            //            .WithMany(e => e.Bookings)
            //            .HasForeignKey(e => e.ManagerId)
            //            .OnDelete(DeleteBehavior.Restrict);
        }
    }    
}
