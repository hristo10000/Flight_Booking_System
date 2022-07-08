using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Flinder.Web.Data;
using Flinder.Web.Models;

namespace Flinder.Web.Controllers
{
    public class SeatsController : Controller
    {
        private readonly FlinderDbContext _context;

        public SeatsController(FlinderDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AllSeats(int flightId)
        {
            IEnumerable < Seat > seats = _context.Seat.Where(s => s.Flight_Id == flightId).OrderBy(s => s.Seat_Class).ThenBy(s => s.Row).ThenBy(s => s.Col);
            return View(seats);
        }
        public async Task<IActionResult> Book(int id) {
            _context.Seat.FirstOrDefault(s => s.Id == id).Is_Booked = true;
            _context.SaveChanges();
            /*return RedirectToAction("AllSeats", "Seats", _context.Seat.FirstOrDefault(s => s.Id == id).Flight_Id);*/
            return View("AllSeats", _context.Seat.Where(s => s.Flight_Id == _context.Seat.FirstOrDefault(s => s.Id == id).Flight_Id));
        }
        public async Task<IActionResult> Unbook(int id)
        {
            _context.Seat.FirstOrDefault(s => s.Id == id).Is_Booked = false;
            _context.SaveChanges();
            return View("AllSeats", _context.Seat.Where(s => s.Flight_Id == _context.Seat.FirstOrDefault(s => s.Id == id).Flight_Id));
        }
        private bool SeatExists(int id)
        {
            return _context.Seat.Any(e => e.Id == id);
        }
    }
}
