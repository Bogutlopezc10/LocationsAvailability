namespace LocationsAvailability.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }
    }
}
