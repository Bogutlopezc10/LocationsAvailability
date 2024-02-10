﻿using LocationsAvailability.Models;

namespace LocationsAvailability.Queries.Interfaces
{
    public interface ILocationQueries
    {
        Task<List<Location>> FindAllAsync();
        Task<Location> FindByIdAsync(Guid id);
        Task CreateLocationAsync(Location location);
    }
}
