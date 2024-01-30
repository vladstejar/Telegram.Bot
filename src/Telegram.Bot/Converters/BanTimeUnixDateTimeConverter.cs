namespace Telegram.Bot.Converters;

internal class BanTimeUnixDateTimeConverter : NullableUnixDateTimeConverter
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var clonedReader = reader;
        var value = clonedReader.GetInt64();

        return value is 0L
            ? null
            : base.Read(ref reader, typeToConvert, options);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value is null || value.Value == default)
            writer.WriteNumberValue(0);
        else
            base.Write(writer, value, options);
    }
}
