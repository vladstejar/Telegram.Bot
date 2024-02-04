namespace Telegram.Bot.Types;

/// <summary>
/// This object represents the bot's short description.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class BotShortDescription
{
    /// <summary>
    /// The bot's short description
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string ShortDescription { get; set; } = default!;
}
