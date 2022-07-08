using Flinder.Web.Controllers;
using Flinder.Web.Data;
using Flinder.Web.Models;
using Flinder.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Flinder.Web.Tests
{
    class AirportControllerTests
    {
        private AirportService _service;
        private FlinderDbContext _context;
        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<FlinderDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
            _context = new FlinderDbContext(dbContextOptions);
            _service = new AirportService(_context);

        }
        [Test]
        public void Create_ValidParams_CreatesController()
        {   //Arrange
            var airportController = new AirportsController(_context, _service);

            //Act
            var result = airportController.Create();

            //Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public async Task Create_ValidParams_CreatesAirport()
        {
            //Arrange
            var airportController = new AirportsController(_context, _service);

            //Act
            var result = await airportController.Create(new AirportCreateModel { Airport_Id = "000", Name = "Test Airport Name", Country = "Test Airport Country", City = "Test Airport City", Adress = "Test Airport Adress" });

            //Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public async Task Airport_Index_Delete_With_Params_Test()
        {
            //Arrange
            var airportController = new AirportsController(_context, _service);

            //Act
            var result = await airportController.Delete("000");

            //Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}