using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to change the description of a group, a supergroup or a channel.
/// The bot must be an administrator in the chat for this to work and must have the
/// appropriate admin rights. Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
public class SetChatDescriptionRequest(ChatId chatId) : RequestBase<bool>("setChatDescription"), IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// New chat Description, 0-255 characters
    /// </summary>
    public string? Description { get; set; }
}
