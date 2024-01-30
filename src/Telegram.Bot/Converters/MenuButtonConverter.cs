using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Converters;

internal class MenuButtonConverter : JsonConverter<MenuButton>
{
    public override MenuButton? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var clonedReader = reader;
        var jsonElement = JsonElement.ParseValue(ref clonedReader);
        if (!jsonElement.TryGetProperty("type", out var statusProperty))
            return null;

        var status = statusProperty.Deserialize<MenuButtonType?>();
        var actualType = status switch
        {
            MenuButtonType.Default => typeof(MenuButtonDefault),
            MenuButtonType.Commands => typeof(MenuButtonCommands),
            MenuButtonType.WebApp => typeof(MenuButtonWebApp),
            _ => throw new JsonException($"Unknown chat member status value of '{statusProperty}'")
        };

        return (MenuButton?) JsonSerializer.Deserialize(ref reader, actualType, options);
    }

    public override void Write(Utf8JsonWriter writer, MenuButton value, JsonSerializerOptions options)
        => JsonSerializer.SerializeToElement(value, options).WriteTo(writer);
}
