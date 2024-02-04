#if NET8_0_OR_GREATER

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Converters;

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

#endif
