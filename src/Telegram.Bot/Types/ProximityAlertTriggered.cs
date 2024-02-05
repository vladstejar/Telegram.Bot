namespace Telegram.Bot.Types;

/// <summary>
/// Represents the content of a service message, sent whenever a user in the chat triggers a proximity alert set
/// by another user.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ProximityAlertTriggered
{
    /// <summary>
    /// User that triggered the alert
    /// </summary>
    [DataMember(IsRequired = true)]
    public User Traveler { get; set; } = default!;

    /// <summary>
    /// User that set the alert
    /// </summary>
    [DataMember(IsRequired = true)]
    public User Watcher { get; set; } = default!;

    /// <summary>
    /// The distance between the users
    /// </summary>
    [DataMember(IsRequired = true)]
    public int Distance { get; set; }
}
