using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents one special entity in a text message. For example, hashtags, usernames, URLs, etc.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class MessageEntity
{
    /// <summary>
    /// Type of the entity
    /// </summary>
#if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
#endif
    public MessageEntityType Type { get; set; }

    /// <summary>
    /// Offset in UTF-16 code units to the start of the entity
    /// </summary>
#if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
#endif
    public int Offset { get; set; }

    /// <summary>
    /// Length of the entity in UTF-16 code units
    /// </summary>
#if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
#endif
    public int Length { get; set; }

    /// <summary>
    /// Optional. For <see cref="MessageEntityType.TextLink"/> only, URL that will be opened after user taps on the text
    /// </summary>
#if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
#endif
    public string? Url { get; set; }

    /// <summary>
    /// Optional. For <see cref="MessageEntityType.TextMention"/> only, the mentioned user
    /// </summary>
#if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
#endif
    public User? User { get; set; }

    /// <summary>
    /// Optional. For <see cref="MessageEntityType.Pre"/> only, the programming language of the entity text
    /// </summary>
#if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
#endif
    public string? Language { get; set; }

    /// <summary>
    /// Optional. For <see cref="MessageEntityType.CustomEmoji"/> only, unique identifier of the custom emoji.
    /// Use <see cref="Requests.GetCustomEmojiStickersRequest"/> to get full information about the sticker
    /// </summary>
#if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
#endif
    public string? CustomEmojiId { get; set; }
}
