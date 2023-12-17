using Telegram.Bot.Converters;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get up to date information about the chat (current name of the user for
/// one-on-one conversations, current username of a user, group or channel, etc.).
/// Returns a <see cref="Chat"/> object on success.
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target supergroup or channel
/// (in the format <c>@channelusername</c>)
/// </param>
public class GetChatRequest(ChatId chatId) : RequestBase<Chat>("getChat"), IChatTargetable
{
    /// <inheritdoc />
    [JsonConverter(typeof(ChatIdConverter))]
    public ChatId ChatId { get; } = chatId;
}
