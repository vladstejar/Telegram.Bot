using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method for your bot to leave a group, supergroup or channel. Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target supergroup or channel
/// (in the format <c>@channelusername</c>)
/// </param>
public class LeaveChatRequest(ChatId chatId) : RequestBase<bool>("leaveChat"), IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;
}
