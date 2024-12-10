using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain.ValueObjects
{
    public class DataLancamentoVOConverter : JsonConverter<DataLancamentoVO>
    {
        public override DataLancamentoVO Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateTime = reader.GetDateTime();
            return new DataLancamentoVO(dateTime);
        }

        public override void Write(Utf8JsonWriter writer, DataLancamentoVO value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }
}
