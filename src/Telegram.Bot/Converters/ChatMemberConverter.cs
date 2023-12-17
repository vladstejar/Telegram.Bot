using System.Linq;
using System.Text.Json.Nodes;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Converters;

internal class ChatMemberConverter : JsonConverter<ChatMember>
{
    public override ChatMember? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var chatMemberConverter = options.Converters.First(converter => converter is ChatMemberConverter);
        options.Converters.Remove(chatMemberConverter);
        Utf8JsonReader clonedReader = reader;

        do
        {
            JsonElement? element;
            if (JsonElement.TryParseValue(ref clonedReader, out element))
            {

            }
        } while (clonedReader.Read());

        var jo = JObject.Load(reader);
        var status = jo["status"]?.ToObject<ChatMemberStatus>();

        if (status is null)
        {
            return null;
        }

        var actualType = status switch
        {
            ChatMemberStatus.Creator       => typeof(ChatMemberOwner),
            ChatMemberStatus.Administrator => typeof(ChatMemberAdministrator),
            ChatMemberStatus.Member        => typeof(ChatMemberMember),
            ChatMemberStatus.Left          => typeof(ChatMemberLeft),
            ChatMemberStatus.Kicked        => typeof(ChatMemberBanned),
            ChatMemberStatus.Restricted    => typeof(ChatMemberRestricted),
            _                              => throw new JsonException($"Unknown chat member status value of '{jo["status"]}'")
        };

        // Remove status because status property only has getter
        jo.Remove("status");
        var value = Activator.CreateInstance(actualType)!;
        serializer.Populate(jo.CreateReader(), value);

        return value;
    }

    public override void Write(Utf8JsonWriter writer, ChatMember value, JsonSerializerOptions options)
    {
        var jo = JObject.FromObject(value);
        jo.WriteTo(writer);
    }
}
