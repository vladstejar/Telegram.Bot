namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a service message about a video chat ended in the chat.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class VideoChatEnded
{
    /// <summary>
    /// Video chat duration in seconds
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public int Duration { get; set; }
}
