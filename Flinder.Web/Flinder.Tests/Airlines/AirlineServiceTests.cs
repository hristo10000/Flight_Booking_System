using Flinder.Web.Data;
using Flinder.Web.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace Flinder.Web.Tests
{
    public class AirlineServiceTests
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
        public void Add_ValidAirline_AddsAirlineToDB()
        {
            //Arrange
            var airline = new Airline {Name = "Test Airline"};

            //Act
            _service.Add(airline);

            //Assert
            if (_context.Airline.Any(x => x.Name == "Test Airline"))
                Assert.Pass();
            Assert.Fail();
        }
        [Test]
        public void Get_ExistingAirlineName_ReturnsAirlineWithThisName()
        {
            //Arrange
            _service.Add(new Airline{Name = "Test Airline" });

            //Act
            var airline = _service.Get("Test Airline");

            //Assert
            if (airline.Name == null)
                Assert.Fail();
            Assert.Pass();
        }
        [Test]
        public void Delete_ExistingAirlineName_DeletesAirlineWithThisNameFromDB()
        {
            //Arrange
            _service.Add(new Airline {Name = "Test Airline" });

            //Act
            _service.Delete("Test Airline");

            //Assert
            if (_context.Airline.Any(x => x.Name == "Test Airline"))
                Assert.Fail();
            Assert.Pass();
        }
    }
}