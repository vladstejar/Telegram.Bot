using Telegram.Bot.Converters;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to create a topic in a forum supergroup chat. The bot must be an administrator in the chat for
/// this to work and must have the <see cref="ChatAdministratorRights.CanManageTopics"/> administrator rights.
/// Returns information about the created topic as a <see cref="ForumTopic"/> object.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class CreateForumTopicRequest : RequestBase<ForumTopic>, IChatTargetable
{
    /// <inheritdoc />
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public ChatId ChatId { get; }

    /// <summary>
    /// Topic name, 1-128 characters
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Name { get; }

    /// <summary>
    /// Optional. Color of the topic icon in RGB format. Currently, must be one of 0x6FB9F0, 0xFFD67E, 0xCB86DB,
    /// 0x8EEE98, 0xFF93B2, or 0xFB6F5F
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    [JsonConverter(typeof(ColorConverter))]
    public Color? IconColor { get; set; }

    /// <summary>
    /// Optional. Unique identifier of the custom emoji shown as the topic icon.
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? IconCustomEmojiId { get; set; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup</param>
    /// <param name="name">Topic name</param>
    public CreateForumTopicRequest(ChatId chatId, string name)
        : base("createForumTopic")
    {
        ChatId = chatId;
        Name = name;
    }
}
