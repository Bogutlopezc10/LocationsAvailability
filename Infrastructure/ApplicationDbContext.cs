using Microsoft.EntityFrameworkCore;
using LocationsAvailability.Models;

namespace LocationsAvailability.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; } = null!;
    }
}
