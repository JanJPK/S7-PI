using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class VehicleModelControllerTests
    {
        [Fact]
        public async void Should_Return_VehicleModels()
        {
            // Arrange
            var vehicleModelsQueryable = DataProvider.GetVehicleModels().AsQueryable().BuildMock();
            var vehicleModelRepositoryMock = new Mock<IGenericRepository<VehicleModel, int>>();
            vehicleModelRepositoryMock.Setup(m => m.Get())
                                      .Returns(vehicleModelsQueryable.Object);
            var vehicleModelController = new VehicleModelController(vehicleModelRepositoryMock.Object,
                                                                    Mock.Of<IGenericRepository<Vehicle, int>>(),
                                                                    MapperProvider.GetMapper());
            // Act
            var request = await vehicleModelController.Get(new VehicleModelFilter());
            var result = request as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.StatusCode == 200);
            var dtos = result.Value as List<VehicleModelDto>;
            Assert.NotNull(dtos);
            Assert.True(dtos.Count == 3);
        }

        [Fact]
        public async void Should_Return_Filtered_VehicleModels()
        {
            // Arrange
            var vehicleModelsQueryable = DataProvider.GetVehicleModels().AsQueryable().BuildMock();
            var filter = new VehicleModelFilter
            {
                Manufacturer = "Ford"
            };
            var vehicleModelRepositoryMock = new Mock<IGenericRepository<VehicleModel, int>>();
            vehicleModelRepositoryMock.Setup(m => m.Get())
                                      .Returns(vehicleModelsQueryable.Object);
            var vehicleModelController = new VehicleModelController(vehicleModelRepositoryMock.Object,
                                                                    Mock.Of<IGenericRepository<Vehicle, int>>(),
                                                                    MapperProvider.GetMapper());
            // Act
            var request = await vehicleModelController.Get(filter);
            var result = request as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.StatusCode == 200);
            var dtos = result.Value as List<VehicleModelDto>;
            Assert.NotNull(dtos);
            Assert.True(dtos.Count == 2);
        }

        [Fact]
        public async void Should_Return_VehicleModel_By_Id()
        {
            // Arrange
            var vehicleModels = DataProvider.GetVehicleModels();
            var vehicleModelRepositoryMock = new Mock<IGenericRepository<VehicleModel, int>>();
            vehicleModelRepositoryMock.Setup(m => m.GetById(It.IsAny<int>()))
                                      .Returns<int>(id => Task.FromResult(vehicleModels.SingleOrDefault(vm => vm.Id == id)));
            var vehicleModelController = new VehicleModelController(vehicleModelRepositoryMock.Object,
                                                                    Mock.Of<IGenericRepository<Vehicle, int>>(),
                                                                    MapperProvider.GetMapper());
            // Act
            var request = await vehicleModelController.GetById(1);
            var result = request as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.StatusCode == 200);
        }

        [Fact]
        public async void Should_Return_404_For_Bad_Id()
        {
            // Arrange
            var vehicleModels = DataProvider.GetVehicleModels();
            var vehicleModelRepositoryMock = new Mock<IGenericRepository<VehicleModel, int>>();
            vehicleModelRepositoryMock.Setup(m => m.GetById(It.IsAny<int>()))
                                      .Returns<int>(id => Task.FromResult(vehicleModels.SingleOrDefault(vm => vm.Id == id)));
            var vehicleModelController = new VehicleModelController(vehicleModelRepositoryMock.Object,
                                                                    Mock.Of<IGenericRepository<Vehicle, int>>(),
                                                                    MapperProvider.GetMapper());
            // Act
            var request = await vehicleModelController.GetById(9001);
            var result = request as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.StatusCode == 404);
        }


    }
}
