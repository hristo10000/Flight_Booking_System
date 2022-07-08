using Flinder.Web.Services;
using Flinder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Flinder.Web.Data;
using System.Threading.Tasks;

namespace Flinder.Web.Controllers
{
    public class AirportsController : Controller
    {
        private readonly FlinderDbContext _context;
        private AirportService _service;
        public AirportsController(FlinderDbContext context, AirportService service)
        {
            _context = context;
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AirportCreateModel airport)
        {
            _service.Add(new Airport { Airport_Id = airport.Airport_Id, Name = airport.Name, Adress = airport.Adress, City = airport.City, Country = airport.Country });
            return RedirectToAction("Index", "Airports");
        }
        public async Task<IActionResult> Delete(string id)
        {
            return View(_service.Find(id));
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            _service.Delete(id);
            return RedirectToAction("Index", "Airports");
        }
    }
}