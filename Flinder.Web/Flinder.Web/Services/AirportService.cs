using Flinder.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace Flinder.Web.Services
{
    public class AirportService
    {
        private readonly FlinderDbContext _context;
        public AirportService(FlinderDbContext context)
        {
            _context = context;
        }
        public Airport Get(string id)
        {
            return _context.Airport.FirstOrDefault(a => a.Airport_Id == id);
        }
        public IEnumerable<Airport> GetAll()
        {
            return _context.Airport;
        }
        public void Add(Airport airport)
        {
            _context.Airport.Add(airport);
            _context.SaveChanges();
        }
        public Airport Find(string id)
        {
            return _context.Airport.FirstOrDefault(x => x.Airport_Id == id);
        }
        public void Delete(string id)
        {
            var airport = _context.Airport.FirstOrDefault(x => x.Airport_Id == id);
            _context.Remove(airport);
            _context.SaveChanges();
        }
    }
}