using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class JsonDateTimeConverter : JsonConverter<DateTime>
{
    private readonly string _format = "dd/MM/yyyy HH:mm:ss";
    private readonly TimeZoneInfo _brazilianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateTime = DateTime.ParseExact(reader.GetString(), _format, CultureInfo.InvariantCulture);

        // Convert from Brazilian time zone to UTC (or adjust if necessary)

        return TimeZoneInfo.ConvertTimeToUtc(dateTime, _brazilianTimeZone);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
       
        var brazilianTime = TimeZoneInfo.ConvertTimeFromUtc(value, _brazilianTimeZone);
        writer.WriteStringValue(brazilianTime.ToString(_format));
    }
}
