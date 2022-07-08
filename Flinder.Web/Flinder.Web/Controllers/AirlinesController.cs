using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flinder.Web.Data;
using Flinder.Web.Services;

namespace Flinder.Web.Controllers
{
    public class AirlinesController : Controller
    {
        private readonly FlinderDbContext _context;
        private AirlineService _service;
        public AirlinesController(FlinderDbContext context, AirlineService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(_service.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Airline airline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airline);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airline = await _context.Airline.FindAsync(id);
            _context.Airline.Remove(airline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirlineExists(int id)
        {
            return _context.Airline.Any(e => e.Id == id);
        }
    }
}