using LocationsAvailability.Infrastructure;
using LocationsAvailability.Models;
using LocationsAvailability.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocationsAvailability.Queries
{
    public class LocationQueries : ILocationQueries
    {
        protected readonly ApplicationDbContext _context;
        private readonly TimeOnly firstAvailableTime = new(10, 0);
        private readonly TimeOnly secondAvailableTime = new(13, 0);

        public LocationQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> FindAllAsync()
        {
            var list = await _context.Locations
                .AsNoTracking()
                .Where(l => (l.OpeningTime <= firstAvailableTime && l.ClosingTime >= secondAvailableTime))
                .ToListAsync();

            return list;
        }

        public async Task<Location> FindByIdAsync(Guid id)
        {
            return await _context.Locations.AsNoTracking().FirstOrDefaultAsync(location => location.Id == id);
        }

        public async Task CreateLocationAsync(Location location)
        {
            location.Id = Guid.NewGuid();
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }
    }
}
