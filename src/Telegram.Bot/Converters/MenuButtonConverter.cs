using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Converters;

internal class MenuButtonConverter : JsonConverter<MenuButton>
{
    public override MenuButton? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jo = JObject.Load(reader);
        var typeToken = jo["type"];
        var status = typeToken?.ToObject<MenuButtonType>();

        if (status is null)
        {
            return null;
        }

        var actualType = status switch
        {
            MenuButtonType.Default  => typeof(MenuButtonDefault),
            MenuButtonType.Commands => typeof(MenuButtonCommands),
            MenuButtonType.WebApp   => typeof(MenuButtonWebApp),
            _                       => throw new JsonException($"Unknown menu button type value of '{typeToken}'")
        };

        // Remove status because status property only has getter
        jo.Remove("type");
        var value = Activator.CreateInstance(actualType)!;
        serializer.Populate(jo.CreateReader(), value);

        return value;
    }

    public override void Write(Utf8JsonWriter writer, MenuButton value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNull();
        }
        else
        {
            var jo = JObject.FromObject(value);
            jo.WriteTo(writer);
        }
    }
}
