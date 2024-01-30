using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Converters;

internal class ChatMemberConverter : JsonConverter<ChatMember>
{
    public override bool CanConvert(Type typeToConvert) => typeof(ChatMember) == typeToConvert;

    public override ChatMember? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var clonedReader = reader;
        var jsonElement = JsonElement.ParseValue(ref clonedReader);
        if (!jsonElement.TryGetProperty("status", out var statusProperty))
            return null;

        var status = statusProperty.Deserialize<ChatMemberStatus?>();
        var actualType = status switch
        {
            ChatMemberStatus.Creator       => typeof(ChatMemberOwner),
            ChatMemberStatus.Administrator => typeof(ChatMemberAdministrator),
            ChatMemberStatus.Member        => typeof(ChatMemberMember),
            ChatMemberStatus.Left          => typeof(ChatMemberLeft),
            ChatMemberStatus.Kicked        => typeof(ChatMemberBanned),
            ChatMemberStatus.Restricted    => typeof(ChatMemberRestricted),
            _                              => throw new JsonException($"Unknown chat member status value of '{statusProperty}'")
        };

        return (ChatMember?) JsonSerializer.Deserialize(ref reader, actualType, options);
    }

    public override void Write(Utf8JsonWriter writer, ChatMember value, JsonSerializerOptions options)
        => JsonSerializer.SerializeToElement(value, options).WriteTo(writer);
}
