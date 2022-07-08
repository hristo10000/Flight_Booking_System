using Flinder.Web.Data;
using Flinder.Web.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace Flinder.Web.Tests { 
    public class AirportServiceTests
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
        public void Add_ValidAirportObject_AddsToDB()
        {
            //Arrange
            var airport = new Airport { Airport_Id = "000", Name = "Test Airport Name", Country = "Test Airport Country", City = "Test Airport City", Adress = "Test Airport Adress" };

            //Act
            _service.Add(airport);

            //Assert
            if (_context.Airport.Any(x => x.Airport_Id == "000"))
                Assert.Pass();
            Assert.Fail();
        }
        [Test]
        public void Get_ExistingAirportId_ReturnsAirportWithThisName()
        {
            //Arrange
            _service.Add(new Airport { Airport_Id = "000", Name = "Test Airport Name", Country = "Test Airport Country", City = "Test Airport City", Adress = "Test Airport Adress" });

            //Act
            var airport = _service.Get("000");

            //Assert
            if (airport.Airport_Id == null)
                Assert.Fail();
            Assert.Pass();
        }
        [Test]
        public void Delete_ExistingAirportId_DeletesAirportWithThisNameFromDB()
        {
            //Arrange
            _service.Add(new Airport { Airport_Id = "000", Name = "Test Airport Name", Country = "Test Airport Country", City = "Test Airport City", Adress = "Test Airport Adress" });

            //Act
            _service.Delete("000");

            //Assert
            if (_context.Airport.Any(x => x.Airport_Id == "000"))
                Assert.Fail();
            Assert.Pass();
        }
    }
}