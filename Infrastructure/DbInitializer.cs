using LocationsAvailability.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace LocationsAvailability.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed the database with initial data
            if (!context.Locations.Any())
            {
                context.Locations.AddRange(
                    new Location { Id = 1, Name = "Pharmacy1", OpeningTime = new TimeOnly(7, 0), ClosingTime = new TimeOnly(19, 0) },
                    new Location { Id = 2, Name = "Pharmacy2", OpeningTime = new TimeOnly(8, 0), ClosingTime = new TimeOnly(13, 0) },
                    new Location { Id = 3, Name = "Pharmacy3", OpeningTime = new TimeOnly(7, 0), ClosingTime = new TimeOnly(12, 0) },
                    new Location { Id = 4, Name = "Pharmacy4", OpeningTime = new TimeOnly(9, 0), ClosingTime = new TimeOnly(16, 0) },
                    new Location { Id = 5, Name = "Pharmacy5", OpeningTime = new TimeOnly(11, 0), ClosingTime = new TimeOnly(19, 0) }
                );
                context.SaveChanges();
            }
        }
    }
}
