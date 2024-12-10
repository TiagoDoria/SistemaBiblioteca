using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class NomeVOConverter : JsonConverter<NomeVO>
    {
        public override NomeVO Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var nameString = reader.GetString();
            return new NomeVO(nameString);
        }

        public override void Write(Utf8JsonWriter writer, NomeVO value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }
}
