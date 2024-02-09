using Microsoft.AspNetCore.Mvc;
using LocationsAvailability.Models;
using LocationsAvailability.Queries.Interfaces;

namespace LocationsAvailability.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationQueries _queries;

        public LocationsController(ILocationQueries queries)
        {
            _queries = queries;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocationsAsync()
        {
            return await _queries.FindAllAsync();
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocationByIdAsync(int id)
        {
            var location = await _queries.FindByIdAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // POST: api/Locations
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocationAsync(Location location)
        {
            await _queries.CreateLocationAsync(location);

            var existingLocation = await _queries.FindByIdAsync(location.Id);

            return existingLocation;
        }
    }
}
