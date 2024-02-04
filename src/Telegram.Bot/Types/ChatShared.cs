using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Types;

/// <summary>
/// This object contains information about the chat whose identifier was shared with the bot using a
/// <see cref="KeyboardButtonRequestChat"/> button.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class ChatShared
{
    /// <summary>
    /// Identifier of the request
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public int RequestId { get; set; }

    /// <summary>
    /// Identifier of the shared chat. This number may have more than 32 significant bits and some programming
    /// languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits,
    /// so a 64-bit integer or double-precision float type are safe for storing this identifier. The bot may not have
    /// access to the chat and could be unable to use this identifier, unless the chat is already known to the bot by
    /// some other means.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public long ChatId { get; set; }
}
