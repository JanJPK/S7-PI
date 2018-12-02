using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.DbAccess
{
    public class VehifleetContext 
        : IdentityDbContext<EmployeeIdentity>
    {
        private readonly IUserAuditService userAuditService;

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Employee> Employees { get; set; }       

        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Maintenance> Maintenances { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleModel> VehicleModels { get; set; }

        public VehifleetContext(DbContextOptions<VehifleetContext> options, 
                                IUserAuditService userAuditService
        ) : base(options)
        {
            this.userAuditService = userAuditService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var changedEntries = ChangeTracker.Entries()
                                              .Where(e => e.State == EntityState.Added
                                                       || e.State == EntityState.Modified);

            foreach (var entry in changedEntries)
            {
                var entity = entry.Entity as AuditableEntity;

                if (entity == null)
                {
                    continue;
                }

                if (entry.State == EntityState.Added)
                {
                    entity.AddedBy = userAuditService.UserName;                    
                    entity.AddedOn = DateTime.UtcNow;
                }

                entity.ModifiedBy = userAuditService.UserName;
                entity.ModifiedOn = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Employee>()
            //       .HasMany(e => e.Bookings)
            //       .WithOne(b => b.Employee)
            //       .HasForeignKey(b => b.EmployeeId)
            //       .OnDelete(DeleteBehavior.Restrict)
            //       .IsRequired();

            //builder.Entity<Employee>()
            //       .HasMany(e => e.ManagedBookings)
            //       .WithOne(b => b.Manager)
            //       .HasForeignKey(b => b.ManagerId)
            //       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}