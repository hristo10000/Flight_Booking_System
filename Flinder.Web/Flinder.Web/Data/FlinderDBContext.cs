using Microsoft.EntityFrameworkCore;
using Flinder.Web.Data;

namespace Flinder.Web.Data
{
    public class FlinderDbContext : DbContext
    {
        public DbSet<Airport> Airport { get; set; }
        public FlinderDbContext(DbContextOptions<FlinderDbContext> options) : base(options) { }
        public DbSet<Airline> Airline { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Flinder.Web.Data.Seat> Seat { get; set; }
    }
}