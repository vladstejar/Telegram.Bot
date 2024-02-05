namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a service message about a new forum topic created in the chat.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ForumTopicCreated
{
    /// <summary>
    /// Name of the topic
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Color of the topic icon in RGB format
    /// </summary>
    [DataMember(IsRequired = true)]
    public int IconColor { get; set; }

    /// <summary>
    /// Optional. Unique identifier of the custom emoji shown as the topic icon
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? IconCustomEmojiId { get; set; }
}
