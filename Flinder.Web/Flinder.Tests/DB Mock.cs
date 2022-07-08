using Flinder.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Flinder.Tests
{
    class DB_Mock
    {
        public DbContextOptions<FlinderDbContext> dbContextOptions = new DbContextOptionsBuilder<FlinderDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid()
            .ToString())
            .Options;
    }
}