using System.Net.Http;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send static .WEBP, animated .TGS, or video .WEBM stickers.
/// On success, the sent <see cref="Message"/> is returned.
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
public class SendStickerRequest(ChatId chatId, InputFile sticker)
    : FileRequestBase<Message>("sendSticker"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Optional. Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Sticker to send. Pass a <see cref="InputFileId"/> as String to send a file that
    /// exists on the Telegram servers (recommended), pass an HTTP URL as a String
    /// for Telegram to get a .WEBP sticker from the Internet, or upload a new .WEBP
    /// or .TGS sticker using multipart/form-data.
    /// Video stickers can only be sent by a <see cref="InputFileId"/>.
    /// Animated stickers can't be sent via an HTTP URL.
    /// </summary>
    public InputFile Sticker { get; } = sticker;

    /// <summary>
    /// Optional. Emoji associated with the sticker; only for just uploaded stickers
    /// </summary>
    public string? Emoji { get; set; }

    /// <inheritdoc cref="Documentation.DisableNotification"/>

    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Documentation.ReplyToMessageId"/>

    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Documentation.AllowSendingWithoutReply"/>

    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Documentation.ReplyMarkup"/>

    public IReplyMarkup? ReplyMarkup { get; set; }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent() =>
        Sticker switch
        {
            InputFileStream stickerFile => ToMultipartFormDataContent(fileParameterName: "sticker", inputFile: stickerFile),
            _                           => base.ToHttpContent()
        };
}
