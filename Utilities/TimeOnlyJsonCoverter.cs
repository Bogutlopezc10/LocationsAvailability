using System.Text.Json;
using System.Text.Json.Serialization;

namespace LocationsAvailability.Utilities
{
    public class TimeOnlyJsonCoverter : JsonConverter<TimeOnly>
    {
        private const string TimeFormat = "HH:mm tt";

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException($"Expected string but got {reader.TokenType}.");
            }

            var value = reader.GetString();

            if (TimeOnly.TryParse(value, out var time))
            {
                return time;
            }
            else
            {
                throw new JsonException($"Invalid TimeOnly format: {value}");
            }
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions serializer)
        {
            writer.WriteStringValue(value.ToString(TimeFormat));
        }
    }
}
