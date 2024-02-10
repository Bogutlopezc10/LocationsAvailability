using AutoMapper;
using LocationsAvailability.Commands;
using LocationsAvailability.Models;

namespace LocationsAvailability.Mappings
{
    public class LocationMappings : Profile
    {
        public LocationMappings() 
        {
            CreateMap<CreateLocationCommand, Location>();
        }    
    }
}
