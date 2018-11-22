﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vehifleet.Data.DbAccess;

namespace Vehifleet.Data.DbAccess.Migrations
{
    [DbContext(typeof(VehifleetContext))]
    [Migration("20181119225714_AddedInitialPurchaseCostToVehicleModel")]
    partial class AddedInitialPurchaseCostToVehicleModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Vehifleet.Data.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedBy")
                        .IsRequired();

                    b.Property<DateTime>("AddedOn");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(16, 2)");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("FuelConsumed");

                    b.Property<int?>("ManagerId");

                    b.Property<string>("ManagerNotes");

                    b.Property<int>("Mileage");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Purpose")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("Status");

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Vehifleet.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedBy")
                        .IsRequired();

                    b.Property<DateTime>("AddedOn");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(16, 2)");

                    b.Property<int>("FuelConsumed");

                    b.Property<string>("IdentityId");

                    b.Property<bool>("IsActive");

                    b.Property<int>("Mileage");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId")
                        .IsUnique()
                        .HasFilter("[IdentityId] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Vehifleet.Data.Models.EmployeeIdentity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Department");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Vehifleet.Data.Models.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedBy")
                        .IsRequired();

                    b.Property<DateTime>("AddedOn");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(16, 2)");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("InsuranceId")
                        .IsRequired();

                    b.Property<string>("Insurer")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Mileage");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("Vehifleet.Data.Models.Location", b =>
                {
                    b.Property<string>("LocationCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy")
                        .IsRequired();

                    b.Property<DateTime>("AddedOn");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.HasKey("LocationCode");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Vehifleet.Data.Models.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedBy")
                        .IsRequired();

                    b.Property<DateTime>("AddedOn");

                    b.Property<bool>("Completed");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(16, 2)");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("Mileage");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<bool>("Regular");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("Vehifleet.Data.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedBy")
                        .IsRequired();

                    b.Property<DateTime>("AddedOn");

                    b.Property<DateTime>("CanBeBookedUntil");

                    b.Property<string>("ChassisCode")
                        .IsRequired();

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(16, 2)");

                    b.Property<int>("FuelConsumed");

                    b.Property<DateTime>("InspectionValidUntil");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LocationCode");

                    b.Property<int>("Mileage");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<int>("Status");

                    b.Property<int>("VehicleModelId");

                    b.Property<int>("YearOfManufacture");

                    b.HasKey("Id");

                    b.HasIndex("LocationCode");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Vehifleet.Data.Models.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedBy")
                        .IsRequired();

                    b.Property<DateTime>("AddedOn");

                    b.Property<string>("ConfigurationCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(16, 2)");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int>("FuelConsumed");

                    b.Property<int>("Horsepower");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("Mileage");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<decimal>("PurchaseCost")
                        .HasColumnType("decimal(16, 2)");

                    b.Property<int>("Seats");

                    b.Property<int>("Weight");

                    b.HasKey("Id");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Vehifleet.Data.Models.EmployeeIdentity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Vehifleet.Data.Models.EmployeeIdentity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vehifleet.Data.Models.EmployeeIdentity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Vehifleet.Data.Models.EmployeeIdentity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vehifleet.Data.Models.Booking", b =>
                {
                    b.HasOne("Vehifleet.Data.Models.Employee", "Employee")
                        .WithMany("Bookings")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Vehifleet.Data.Models.Employee", "Manager")
                        .WithMany("ManagedBookings")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Vehifleet.Data.Models.Vehicle", "Vehicle")
                        .WithMany("Bookings")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vehifleet.Data.Models.Employee", b =>
                {
                    b.HasOne("Vehifleet.Data.Models.EmployeeIdentity", "Identity")
                        .WithOne("Employee")
                        .HasForeignKey("Vehifleet.Data.Models.Employee", "IdentityId");
                });

            modelBuilder.Entity("Vehifleet.Data.Models.Insurance", b =>
                {
                    b.HasOne("Vehifleet.Data.Models.Vehicle", "Vehicle")
                        .WithMany("Insurances")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vehifleet.Data.Models.Maintenance", b =>
                {
                    b.HasOne("Vehifleet.Data.Models.Vehicle", "Vehicle")
                        .WithMany("Maintenances")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vehifleet.Data.Models.Vehicle", b =>
                {
                    b.HasOne("Vehifleet.Data.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationCode");

                    b.HasOne("Vehifleet.Data.Models.VehicleModel", "VehicleModel")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
