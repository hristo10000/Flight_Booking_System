using Flinder.Web.Controllers;
using Flinder.Web.Data;
using Flinder.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Flinder.Web.Tests
{
    class AirlinesControllerTests
    {
        private AirlineService _service;
        private FlinderDbContext _context;
        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<FlinderDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
            _context = new FlinderDbContext(dbContextOptions);
            _service = new AirlineService(_context);
        }
        [Test]
        public void Create_ValidController_CreatesController()
        {   //Arrange
            var airlinesController = new AirlinesController(_context, _service);

            //Act
            var result = airlinesController.Create();

            //Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public async Task Create_ValidParameters_CreatesAirline()
        {
            //Arrange
            var airlinesController = new AirlinesController(_context, _service);

            //Act
            var result = await airlinesController.Create(new Airline {Name = "Test Airline"});


            //Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public async Task Delete_ValidParams_DeletesAirline()
        {
            //Arrange
            var airlinesController = new AirlinesController(_context, _service);

            //Act
            _ = await airlinesController.Create(new Airline { Name = "Test Airline" });
            var result = await airlinesController.Delete(1);

            //Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}