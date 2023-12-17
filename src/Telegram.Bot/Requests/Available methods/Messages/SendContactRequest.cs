using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send phone contacts. On success, the sent <see cref="Message"/> is returned.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="phoneNumber">Contact's phone number</param>
/// <param name="firstName">Contact's first name</param>
public class SendContactRequest(ChatId chatId, string phoneNumber, string firstName)
    : RequestBase<Message>("sendContact"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Contact's phone number
    /// </summary>
    public string PhoneNumber { get; } = phoneNumber;

    /// <summary>
    /// Contact's first name
    /// </summary>
    public string FirstName { get; } = firstName;

    /// <summary>
    /// Contact's last name
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Additional data about the contact in the form of a vCard, 0-2048 bytes
    /// </summary>
    public string? Vcard { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    public IReplyMarkup? ReplyMarkup { get; set; }
}
