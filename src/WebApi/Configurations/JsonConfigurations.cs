using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Configurations
{
    public static class JsonConfigurations
    {
        public static IMvcBuilder AddConfiguredJson(this IMvcBuilder builder)
        {
            return builder.AddJsonOptions(o =>
                {
                    var converters = o.JsonSerializerOptions.Converters;
                    converters.Add(new JsonStringEnumConverter());
                    converters.Add(new TimeSpanConverter());
                }
            );
        }
    }

    public class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            TimeSpan.Parse(reader.GetString()!);

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value.ToString());
    }
}
