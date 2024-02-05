namespace Telegram.Bot.Types;

/// <summary>
/// This object represents the bot's short description.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class BotShortDescription
{
    /// <summary>
    /// The bot's short description
    /// </summary>
    [DataMember(IsRequired = true)]
    public string ShortDescription { get; set; } = default!;
}
