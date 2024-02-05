#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
#else
using Newtonsoft.Json.Converters;
#endif
using Telegram.Bot.Converters;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a forum topic.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ForumTopic
{
    /// <summary>
    /// Unique identifier of the forum topic
    /// </summary>
    [DataMember(IsRequired = true)]
    public int MessageThreadId { get; set; }

    /// <summary>
    /// Name of the topic
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Color of the topic icon in RGB format
    /// </summary>
    [DataMember(IsRequired = true)]
    [JsonConverter(typeof(ColorConverter))]
    public Color IconColor { get; set; }

    /// <summary>
    /// Optional. Unique identifier of the custom emoji shown as the topic icon
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? IconCustomEmojiId { get; set; }
}
