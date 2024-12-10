using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain.ValueObjects
{
    public class DataNascimentoVOConverter : JsonConverter<DataNascimentoVO>
    {
        public override DataNascimentoVO Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateTime = reader.GetDateTime();
            return new DataNascimentoVO(dateTime);
        }

        public override void Write(Utf8JsonWriter writer, DataNascimentoVO value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }
}
