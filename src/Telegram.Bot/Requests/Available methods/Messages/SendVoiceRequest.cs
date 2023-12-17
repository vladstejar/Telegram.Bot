using System.Collections.Generic;
using System.Net.Http;
using JetBrains.Annotations;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send audio files, if you want Telegram clients to display the file as a playable
/// voice message. For this to work, your audio must be in an .OGG file encoded with OPUS (other
/// formats may be sent as <see cref="Audio"/> or <see cref="Document"/>). On success, the sent
/// <see cref="Message"/> is returned. Bots can currently send voice messages of up to 50 MB in size,
/// this limit may be changed in the future.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="voice">
/// Audio file to send. Pass a <see cref="InputFileId"/> as String to send a file
/// that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram
/// to get a file from the Internet, or upload a new one using multipart/form-data
/// </param>
[PublicAPI]
public class SendVoiceRequest(ChatId chatId, InputFile voice)
    : FileRequestBase<Message>("sendVoice"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Audio file to send. Pass a <see cref="InputFileId"/> as String to send a file that
    /// exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to get
    /// a file from the Internet, or upload a new one using multipart/form-data
    /// </summary>
    public InputFile Voice { get; } = voice;

    /// <summary>
    /// Voice message caption, 0-1024 characters after entities parsing
    /// </summary>
    public string? Caption { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ParseMode"/>
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.CaptionEntities"/>
    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    /// <summary>
    /// Duration of the voice message in seconds
    /// </summary>
    public int? Duration { get; set; }

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

    /// <inheritdoc />
    public override HttpContent? ToHttpContent() =>
        Voice switch
        {
            InputFileStream voiceFile => ToMultipartFormDataContent(fileParameterName: "voice", inputFile: voiceFile),
            _                         => base.ToHttpContent()
        };
}
