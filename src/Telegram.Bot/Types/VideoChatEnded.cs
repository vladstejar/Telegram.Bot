namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a service message about a video chat ended in the chat.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class VideoChatEnded
{
    /// <summary>
    /// Video chat duration in seconds
    /// </summary>
    [DataMember(IsRequired = true)]
    public int Duration { get; set; }
}
