using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send a game. On success, the sent <see cref="Message"/> is returned.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat</param>
/// <param name="gameShortName">
/// Short name of the game, serves as the unique identifier for the game. Set up your games via
/// <a href="https://t.me/botfather">@BotFather</a>
/// </param>
public class SendGameRequest(long chatId, string gameShortName)
    : RequestBase<Message>("sendGame"),
      IChatTargetable
{
    /// <summary>
    /// Unique identifier for the target chat
    /// </summary>
    public long ChatId { get; } = chatId;

    /// <inheritdoc />
    ChatId IChatTargetable.ChatId => ChatId;

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Short name of the game, serves as the unique identifier for the game. Set up your games
    /// via <a href="https://t.me/botfather">@BotFather</a>
    /// </summary>
    public string GameShortName { get; } = gameShortName;

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.InlineReplyMarkup"/>
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}
