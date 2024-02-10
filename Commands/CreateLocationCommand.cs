using System.ComponentModel.DataAnnotations;

namespace LocationsAvailability.Commands
{
    public class CreateLocationCommand
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public TimeOnly OpeningTime { get; set; }
        [Required]
        public TimeOnly ClosingTime { get; set; }
    }
}
