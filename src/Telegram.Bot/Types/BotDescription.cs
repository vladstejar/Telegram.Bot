namespace Telegram.Bot.Types;

/// <summary>
/// This object represents the bot's description.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class BotDescription
{
    /// <summary>
    /// The bot's description
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Description { get; set; } = default!;
}
