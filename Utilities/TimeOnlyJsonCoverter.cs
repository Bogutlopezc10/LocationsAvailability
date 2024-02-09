using System.Text.Json;
using System.Text.Json.Serialization;

namespace LocationsAvailability.Utilities
{
    public class TimeOnlyJsonCoverter : JsonConverter<TimeOnly>
    {
        private const string TimeFormat = "HH:mm tt";

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            return TimeOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions serializer)
        {
            writer.WriteStringValue(value.ToString(TimeFormat));
        }
    }
}
