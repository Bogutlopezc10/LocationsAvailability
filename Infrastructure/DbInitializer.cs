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
                    new Location { Id = Guid.NewGuid(), Name = "Pharmacy", OpeningTime = new TimeOnly(7, 0), ClosingTime = new TimeOnly(19, 0) },
                    new Location { Id = Guid.NewGuid(), Name = "Hotel", OpeningTime = new TimeOnly(0, 0), ClosingTime = new TimeOnly(23, 0) },
                    new Location { Id = Guid.NewGuid(), Name = "Gym", OpeningTime = new TimeOnly(5, 0), ClosingTime = new TimeOnly(22, 0) },
                    new Location { Id = Guid.NewGuid(), Name = "Restaurant", OpeningTime = new TimeOnly(12, 0), ClosingTime = new TimeOnly(22, 0) },
                    new Location { Id = Guid.NewGuid(), Name = "Candy store", OpeningTime = new TimeOnly(9, 0), ClosingTime = new TimeOnly(20, 0) },
                    new Location { Id = Guid.NewGuid(), Name = "Nightclub", OpeningTime = new TimeOnly(18, 0), ClosingTime = new TimeOnly(23, 0) },
                    new Location { Id = Guid.NewGuid(), Name = "Dance Academy", OpeningTime = new TimeOnly(16, 0), ClosingTime = new TimeOnly(19, 0) },
                    new Location { Id = Guid.NewGuid(), Name = "Library", OpeningTime = new TimeOnly(8, 0), ClosingTime = new TimeOnly(18, 0) },
                    new Location { Id = Guid.NewGuid(), Name = "Museum", OpeningTime = new TimeOnly(13, 0), ClosingTime = new TimeOnly(20, 0) },
                    new Location { Id = Guid.NewGuid(), Name = "Laboratory", OpeningTime = new TimeOnly(11, 0), ClosingTime = new TimeOnly(20, 0) }
                );
                context.SaveChanges();
            }
        }
    }
}
