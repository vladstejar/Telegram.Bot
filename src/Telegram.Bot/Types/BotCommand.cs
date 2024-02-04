namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a bot command
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class BotCommand
{
    /// <summary>
    /// Text of the command, 1-32 characters. Can contain only lowercase English letters, digits and underscores.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Command { get; set; } = default!;

    /// <summary>
    /// Description of the command, 3-256 characters.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Description { get; set; } = default!;
}
