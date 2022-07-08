using Flinder.Web.Data;
using Flinder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Diagnostics;
using System.Linq;

namespace Flinder.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FlinderDbContext _context;
        public HomeController(ILogger<HomeController> logger, FlinderDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new SearchFlightModel { AirportNames = _context.Airport.Select(f => f.Name).ToList() };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SearchFlight(SearchFlightModel model)
        {
            IEnumerable FoundFlights = _context.Flight.Where(f => f.Origin_Airport_Name == model.OriginAirportName && f.Destination_Airport_Name==model.DestinationAirportName).ToList();
            return View(FoundFlights);
        }

    }
}