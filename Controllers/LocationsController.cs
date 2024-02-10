using Microsoft.AspNetCore.Mvc;
using LocationsAvailability.Models;
using LocationsAvailability.Queries.Interfaces;
using LocationsAvailability.Commands;
using AutoMapper;

namespace LocationsAvailability.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationQueries _queries;
        private readonly IMapper _mapper;

        public LocationsController(ILocationQueries queries, IMapper mapper)
        {
            _queries = queries;
            _mapper = mapper;  
        }

        // GET: api/Locations
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocationsAsync()
        {
            return await _queries.FindAllAsync();
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Location>> GetLocationByIdAsync(Guid id)
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
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Location?>> PostLocationAsync(CreateLocationCommand createLocationCommand)
        {
            if(createLocationCommand.OpeningTime > createLocationCommand.ClosingTime)
            {
                return BadRequest("The opening time should be less than the closing time.");
            }

            var location = _mapper.Map<Location>(createLocationCommand);

            await _queries.CreateLocationAsync(location);

            var existingLocation = await _queries.FindByIdAsync(location.Id);

            return existingLocation;
        }
    }
}
