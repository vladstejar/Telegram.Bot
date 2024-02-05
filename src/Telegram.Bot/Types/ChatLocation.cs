namespace Telegram.Bot.Types;

/// <summary>
/// Represents a location to which a chat is connected.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ChatLocation
{
    /// <summary>
    /// The location to which the supergroup is connected. Can't be a live location.
    /// </summary>
    [DataMember(IsRequired = true)]
    public Location Location { get; set; } = default!;

    /// <summary>
    /// Location address; 1-64 characters, as defined by the chat owner
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Address { get; set; } = default!;
}
