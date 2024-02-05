using System.Runtime.Serialization;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents one special entity in a text message. For example, hashtags, usernames, URLs, etc.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class MessageEntity
{
    /// <summary>
    /// Type of the entity
    /// </summary>
    [DataMember(IsRequired = true)]
    public MessageEntityType Type { get; set; }

    /// <summary>
    /// Offset in UTF-16 code units to the start of the entity
    /// </summary>
    [DataMember(IsRequired = true)]
    public int Offset { get; set; }

    /// <summary>
    /// Length of the entity in UTF-16 code units
    /// </summary>
    [DataMember(IsRequired = true)]
    public int Length { get; set; }

    /// <summary>
    /// Optional. For <see cref="MessageEntityType.TextLink"/> only, URL that will be opened after user taps on the text
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Url { get; set; }

    /// <summary>
    /// Optional. For <see cref="MessageEntityType.TextMention"/> only, the mentioned user
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public User? User { get; set; }

    /// <summary>
    /// Optional. For <see cref="MessageEntityType.Pre"/> only, the programming language of the entity text
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Language { get; set; }

    /// <summary>
    /// Optional. For <see cref="MessageEntityType.CustomEmoji"/> only, unique identifier of the custom emoji.
    /// Use <see cref="Requests.GetCustomEmojiStickersRequest"/> to get full information about the sticker
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? CustomEmojiId { get; set; }
}
