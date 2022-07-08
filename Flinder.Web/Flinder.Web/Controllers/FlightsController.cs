using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flinder.Web.Data;
using Flinder.Web.Models;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;

namespace Flinder.Web.Controllers
{
    public class FlightsController : Controller
    {
        private readonly FlinderDbContext _context;
        public FlightsController(FlinderDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flight.ToListAsync());
        }
        public IActionResult Create()
        {
            return View(new FlightCreateModel { AirlineNames = GetAllAirlines(), AirportIds = GetAllAirports() });
        }
        private List<string> GetAllAirlines()
        {
            return _context.Airline.Select(f => f.Name).ToList();
        }
        private List<string> GetAllAirports()
        {
            return _context.Airport.Select(f => f.Name).ToList();
        }

        private bool ParseSeatSection(int index, IFormCollection formResult, out string type, out int rows, out int cols)
        {
            type = null;
            rows = 0;
            cols = 0;
            StringValues outStringValues;
            bool result=true;
            if (formResult.TryGetValue($"Classes[{index}][Type]", out outStringValues))
            {
                type = outStringValues;
            }
            else
            {
                result = false;
            }
            if (formResult.TryGetValue($"Classes[{index}][Rows]", out outStringValues))
            {
                rows = int.Parse(outStringValues);
            }
            else
            {
                result = false;
            }
            if (formResult.TryGetValue($"Classes[{index}][Cols]", out outStringValues))
            {
                cols = int.Parse(outStringValues);
            }
            else
            {
                result = false;
            }
            return result;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FlightCreateModel model)
        {
            var flight = new Flight
            {
                Airline_Name = model.Airline_Name,
                Origin_Airport_Name = model.Origin_Airport_Name,
                Destination_Airport_Name = model.Destination_Airport_Name,
                TakeOff_Time = model.TakeOff_Time,
                Landing_Time = model.Landing_Time
            };
            _context.Add(flight);
            _context.SaveChanges();

            var formResult = Request.Form;
            string classType;
            int rows;
            int cols;
            for (int index = 1; index <= 3; index++)
            {
                if(ParseSeatSection(index, formResult, out classType, out rows, out cols))
                {
                    for (int i = 1; i <= rows; i++)
                    {
                        for (int j = 1; j <= cols; j++)
                        {
                            var col = 'A';
                            switch (j)
                            {
                                case 1:
                                    col = 'A';
                                    break;
                                case 2:
                                    col = 'B';
                                    break;
                                case 3:
                                    col = 'C';
                                    break;
                                case 4:
                                    col = 'D';
                                    break;
                                case 5:
                                    col = 'E';
                                    break;
                                case 6:
                                    col = 'F';
                                    break;
                            }
                            _context.Add(new Seat
                            {
                                Flight_Id = _context.Flight.ToArray().Last().Id,
                                Seat_Class = classType,
                                Is_Booked = false,
                                Row = i,
                                Col = col
                            });
                        }
                    }
                }
                
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Flights");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flight.FindAsync(id);
            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.Id == id);
        }
    }
}