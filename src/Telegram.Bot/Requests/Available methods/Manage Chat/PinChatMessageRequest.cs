using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to add a message to the list of pinned messages in a chat. If the chat is not a
/// private chat, the bot must be an administrator in the chat for this to work and must have the
/// '<see cref="ChatPermissions.CanPinMessages"/>' admin right in a supergroup or
/// '<see cref="ChatMemberAdministrator.CanEditMessages"/>' admin right in a channel.
/// Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="messageId">Identifier of a message to pin</param>
public class PinChatMessageRequest(ChatId chatId, int messageId)
    : RequestBase<bool>("pinChatMessage"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Identifier of a message to pin
    /// </summary>
    public int MessageId { get; } = messageId;

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    public bool? DisableNotification { get; set; }
}
