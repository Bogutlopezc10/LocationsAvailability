using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocationsAvailability.Infrastructure;
using LocationsAvailability.Models;
using LocationsAvailability.Queries.Interfaces;

namespace LocationsAvailability.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILocationQueries _queries;

        public LocationsController(ApplicationDbContext context, ILocationQueries queries)
        {
            _context = context;
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
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            var existingLocation = await _queries.FindByIdAsync(location.Id);

            return existingLocation;
        }
    }
}
