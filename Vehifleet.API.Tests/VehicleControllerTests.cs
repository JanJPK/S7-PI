using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockQueryable.Moq;
using Moq;
using Vehifleet.API.Controllers;
using Vehifleet.API.QueryFilters;
using Vehifleet.API.Tests.Helper;
using Vehifleet.Data.Dtos;
using Vehifleet.Data.Models;
using Vehifleet.Repositories.Interfaces;
using Xunit;

namespace Vehifleet.API.Tests
{
    public class VehicleControllerTests
    {
        [Fact]
        public async void Should_Return_Vehicles()
        {
            // Arrange            
            var vehicles = DataProvider.GetVehicles();
            var vehiclesMock = vehicles.AsQueryable().BuildMock();
            var vehicleRepositoryMock = new Mock<IGenericRepository<Vehicle, int>>();
            vehicleRepositoryMock.Setup(m => m.Get()).Returns(vehiclesMock.Object);
            var vehicleController = new VehicleController(vehicleRepositoryMock.Object,
                                                          Mock.Of<IGenericRepository<VehicleModel, int>>(),
                                                          Mock.Of<IGenericRepository<Booking, int>>(),
                                                          Mock.Of<IGenericRepository<Insurance, int>>(),
                                                          MapperProvider.GetMapper());
            // Act
            var request = await vehicleController.Get(new VehicleFilter());
            var result = request as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.StatusCode == 200);
            var dtos = result.Value as List<VehicleListItemDto>;
            Assert.NotNull(dtos);
            Assert.True(dtos.Count == 3);
        }

        [Fact]
        public async void Should_Return_Filtered_Vehicles()
        {
            // Arrange            
            var vehicles = DataProvider.GetVehicles();
            var vehiclesMock = vehicles.AsQueryable().BuildMock();
            var filter = new VehicleFilter
            {
                Manufacturer = "Ford"
            };
            var vehicleRepositoryMock = new Mock<IGenericRepository<Vehicle, int>>();
            vehicleRepositoryMock.Setup(m => m.Get()).Returns(vehiclesMock.Object);
            var vehicleController = new VehicleController(vehicleRepositoryMock.Object,
                                                          Mock.Of<IGenericRepository<VehicleModel, int>>(),
                                                          Mock.Of<IGenericRepository<Booking, int>>(),
                                                          Mock.Of<IGenericRepository<Insurance, int>>(),
                                                          MapperProvider.GetMapper());
            // Act
            var request = await vehicleController.Get(filter);
            var result = request as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.StatusCode == 200);
            var dtos = result.Value as List<VehicleListItemDto>;
            Assert.NotNull(dtos);
            Assert.True(dtos.Count == 2);
        }

        [Fact]
        public async void Should_Return_Vehicle_By_Id()
        {
            // Arrange            
            var vehicles = DataProvider.GetVehicles();
            var bookingsMock = new List<Booking>().AsQueryable().BuildMock();
            var vehicleRepositoryMock = new Mock<IGenericRepository<Vehicle, int>>();
            vehicleRepositoryMock.Setup(m => m.GetById(It.IsAny<int>()))
                                 .Returns<int>(id => Task.FromResult(vehicles.SingleOrDefault(v => v.Id == id)));
            var bookingRepositoryMock = new Mock<IGenericRepository<Booking, int>>();
            bookingRepositoryMock.Setup(m => m.Get())
                                 .Returns(bookingsMock.Object);
            var vehicleController = new VehicleController(vehicleRepositoryMock.Object,
                                                          Mock.Of<IGenericRepository<VehicleModel, int>>(),
                                                          bookingRepositoryMock.Object,
                                                          Mock.Of<IGenericRepository<Insurance, int>>(),
                                                          MapperProvider.GetMapper());
            // Act
            var request = await vehicleController.GetById(1);
            var result = request as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.StatusCode == 200);
        }

        [Fact]
        public async void Should_Return_404_For_Bad_Id()
        {
            // Arrange            
            var vehicles = DataProvider.GetVehicles();
            var bookingsMock = new List<Booking>().AsQueryable().BuildMock();
            var vehicleRepositoryMock = new Mock<IGenericRepository<Vehicle, int>>();
            vehicleRepositoryMock.Setup(m => m.GetById(It.IsAny<int>()))
                                 .Returns<int>(id => Task.FromResult(vehicles.SingleOrDefault(v => v.Id == id)));
            var bookingRepositoryMock = new Mock<IGenericRepository<Booking, int>>();
            bookingRepositoryMock.Setup(m => m.Get())
                                 .Returns(bookingsMock.Object);
            var vehicleController = new VehicleController(vehicleRepositoryMock.Object,
                                                          Mock.Of<IGenericRepository<VehicleModel, int>>(),
                                                          bookingRepositoryMock.Object,
                                                          Mock.Of<IGenericRepository<Insurance, int>>(),
                                                          MapperProvider.GetMapper());
            // Act
            var request = await vehicleController.GetById(9001);
            var result = request as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.StatusCode == 404);
        }
    }
}