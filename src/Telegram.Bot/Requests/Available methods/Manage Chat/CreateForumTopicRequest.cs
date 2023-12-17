using Telegram.Bot.Converters;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to create a topic in a forum supergroup chat. The bot must be an administrator in the chat for
/// this to work and must have the <see cref="ChatAdministratorRights.CanManageTopics"/> administrator rights.
/// Returns information about the created topic as a <see cref="ForumTopic"/> object.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target supergroup</param>
/// <param name="name">Topic name</param>
public class CreateForumTopicRequest(ChatId chatId, string name)
    : RequestBase<ForumTopic>("createForumTopic"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Topic name, 1-128 characters
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// Optional. Color of the topic icon in RGB format. Currently, must be one of 0x6FB9F0, 0xFFD67E, 0xCB86DB,
    /// 0x8EEE98, 0xFF93B2, or 0xFB6F5F
    /// </summary>
    [JsonConverter(typeof(NullableColorConverter))]
    public Color? IconColor { get; set; }

    /// <summary>
    /// Optional. Unique identifier of the custom emoji shown as the topic icon.
    /// </summary>
    public string? IconCustomEmojiId { get; set; }
}
