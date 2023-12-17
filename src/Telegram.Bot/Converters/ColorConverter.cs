namespace Telegram.Bot.Converters;

internal class NullableColorConverter : JsonConverter<Color?>
{
    public override Color? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType is JsonTokenType.Number
            ? new Color(reader.GetUInt32())
            : throw new JsonException();

    public override void Write(Utf8JsonWriter writer, Color? value, JsonSerializerOptions options)
    {
        if (value?.ToInt() is { } colorValue)
        {
            writer.WriteNumberValue(colorValue);
        }
        else if (options.DefaultIgnoreCondition is JsonIgnoreCondition.Never)
        {
            writer.WriteNullValue();
        }
    }
}

internal class ColorConverter : JsonConverter<Color>
{
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => JsonElement.TryParseValue(ref reader, out var element)
           && element.Value.TryGetUInt32(out var intValue)
            ? new Color(intValue)
            : new();

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        => writer.WriteNumberValue(value.ToInt());
}
