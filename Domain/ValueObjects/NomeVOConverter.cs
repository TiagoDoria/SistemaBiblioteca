using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain.ValueObjects
{
    public class NomeVOConverter : JsonConverter<NomeVO>
    {
        public override NomeVO Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // O valor é simplesmente a string representando o nome
            var value = reader.GetString();
            return new NomeVO(value);
        }

        public override void Write(Utf8JsonWriter writer, NomeVO value, JsonSerializerOptions options)
        {
            // Durante a serialização, apenas escreva o valor do nome
            writer.WriteStringValue(value.Value);
        }
    }
}
