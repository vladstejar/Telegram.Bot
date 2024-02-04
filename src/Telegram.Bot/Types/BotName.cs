namespace Telegram.Bot.Types;

/// <summary>
/// This object represents the bot's name.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class BotName
{
    /// <summary>
    /// The bot's name
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Name { get; set; } = default!;
}
