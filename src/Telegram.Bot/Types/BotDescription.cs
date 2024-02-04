namespace Telegram.Bot.Types;

/// <summary>
/// This object represents the bot's description.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class BotDescription
{
    /// <summary>
    /// The bot's description
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Description { get; set; } = default!;
}
