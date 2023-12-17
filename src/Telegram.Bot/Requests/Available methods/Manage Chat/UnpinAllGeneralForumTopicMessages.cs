using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to clear the list of pinned messages in a General forum topic. The bot must be an administrator in
/// the chat for this to work and must have the <see cref="ChatAdministratorRights.CanPinMessages"/> administrator right in the supergroup.
/// Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target supergroup</param>
public class UnpinAllGeneralForumTopicMessages(ChatId chatId)
    : RequestBase<bool>("unpinAllGeneralForumTopicMessages"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;
}
