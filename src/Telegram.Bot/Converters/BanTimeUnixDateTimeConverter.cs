namespace Telegram.Bot.Converters;

internal class BanTimeUnixDateTimeConverter : UnixDateTimeConverter
{
    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var nonNullable = Nullable.GetUnderlyingType(typeToConvert) is null;
        return reader.TokenType is JsonTokenType.Number &&
               reader.GetInt64() is 0L
            ? nonNullable
                ? 0L
                : null
            : base.Read(ref reader, typeToConvert, options);
    }

    public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case null:
            case DateTime dateTime when dateTime == default:
            case DateTimeOffset dateTimeOffset when dateTimeOffset == default:
                writer.WriteNumberValue(0);
                break;
            default:
                base.Write(writer, value, options);
                break;
        }
    }
}
