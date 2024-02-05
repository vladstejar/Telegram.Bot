using System.Net.Http;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send static .WEBP, animated .TGS, or video .WEBM stickers.
/// On success, the sent <see cref="Message"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SendStickerRequest : FileRequestBase<Message>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Optional. Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Sticker to send. Pass a <see cref="InputFileId"/> as String to send a file that
    /// exists on the Telegram servers (recommended), pass an HTTP URL as a String
    /// for Telegram to get a .WEBP sticker from the Internet, or upload a new .WEBP
    /// or .TGS sticker using multipart/form-data.
    /// Video stickers can only be sent by a <see cref="InputFileId"/>.
    /// Animated stickers can't be sent via an HTTP URL.
    /// </summary>
    [DataMember(IsRequired = true)]
    public InputFile Sticker { get; }

    /// <summary>
    /// Optional. Emoji associated with the sticker; only for just uploaded stickers
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Emoji { get; set; }

    /// <inheritdoc cref="Documentation.DisableNotification"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Documentation.ReplyToMessageId"/>
    [DataMember(EmitDefaultValue = false)]
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Documentation.AllowSendingWithoutReply"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Documentation.ReplyMarkup"/>
    [DataMember(EmitDefaultValue = false)]
    public IReplyMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request chatId and sticker
    /// </summary>
    /// <param name="chatId">
    /// Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="sticker">
    /// Sticker to send. Pass a <see cref="InputFileId"/> as String to send a file that
    /// exists on the Telegram servers (recommended), pass an HTTP URL as a String
    /// for Telegram to get a .WEBP sticker from the Internet, or upload a new .WEBP
    /// or .TGS sticker using multipart/form-data.
    /// Video stickers can only be sent by a <see cref="InputFileId"/>.
    /// Animated stickers can't be sent via an HTTP URL.
    /// </param>
    public SendStickerRequest(ChatId chatId, InputFile sticker)
        : base("sendSticker")
    {
        ChatId = chatId;
        Sticker = sticker;
    }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent() =>
        Sticker switch
        {
            InputFileStream sticker => ToMultipartFormDataContent(fileParameterName: "sticker", inputFile: sticker),
            _                       => base.ToHttpContent()
        };
}
