using Flinder.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace Flinder.Web.Services
{
    public class AirlineService
    {
        private readonly FlinderDbContext _context;
        public AirlineService(FlinderDbContext context)
        {
            _context = context;
        }
        public Airline Get(string name)
        {
            return _context.Airline.FirstOrDefault(a => a.Name == name);
        }
        public IEnumerable<Airline> GetAll()
        {
            return _context.Airline;
        }
        public void Add(Airline airline)
        {
            _context.Airline.Add(airline);
            _context.SaveChanges();
        }
        public Airline Find(string name)
        {
            return _context.Airline.FirstOrDefault(x => x.Name == name);
        }
        public void Delete(string name)
        {
            var airline = _context.Airline.FirstOrDefault(x => x.Name == name);
            _context.Remove(airline);
            _context.SaveChanges();
        }
    }
}