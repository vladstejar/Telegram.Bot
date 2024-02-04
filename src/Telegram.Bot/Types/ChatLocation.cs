namespace Telegram.Bot.Types;

/// <summary>
/// Represents a location to which a chat is connected.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class ChatLocation
{
    /// <summary>
    /// The location to which the supergroup is connected. Can't be a live location.
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public Location Location { get; set; } = default!;

    /// <summary>
    /// Location address; 1-64 characters, as defined by the chat owner
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Address { get; set; } = default!;
}
