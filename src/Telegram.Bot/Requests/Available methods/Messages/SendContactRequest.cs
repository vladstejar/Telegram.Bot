using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send phone contacts. On success, the sent <see cref="Message"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SendContactRequest : RequestBase<Message>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Contact's phone number
    /// </summary>
    [DataMember(IsRequired = true)]
    public string PhoneNumber { get; }

    /// <summary>
    /// Contact's first name
    /// </summary>
    [DataMember(IsRequired = true)]
    public string FirstName { get; }

    /// <summary>
    /// Contact's last name
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? LastName { get; set; }

    /// <summary>
    /// Additional data about the contact in the form of a vCard, 0-2048 bytes
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Vcard { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    [DataMember(EmitDefaultValue = false)]
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    [DataMember(EmitDefaultValue = false)]
    public IReplyMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with chatId, phoneNumber and firstName
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="phoneNumber">Contact's phone number</param>
    /// <param name="firstName">Contact's first name</param>
    public SendContactRequest(ChatId chatId, string phoneNumber, string firstName)
        : base("sendContact")
    {
        ChatId = chatId;
        PhoneNumber = phoneNumber;
        FirstName = firstName;
    }
}
