using AirlineBOOM.Models;
using startTemplate.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace startTemplate.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        // My tables
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Pilot> Pilots { get; set; }

        // Context constructor without options
        public AppDbContext()
        {

        }

        // Context constructor with options
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
