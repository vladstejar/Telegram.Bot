// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get the current value of the bot’s menu button in a private chat, or the default menu button.
/// Returns <see cref="MenuButton"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class GetChatMenuButtonRequest : RequestBase<MenuButton>
{
    /// <summary>
    /// Optional. Unique identifier for the target private chat. If not specified, default bot’s menu button
    /// will be changed
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public long? ChatId { get; set; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public GetChatMenuButtonRequest()
        : base("getChatMenuButton")
    { }
}
