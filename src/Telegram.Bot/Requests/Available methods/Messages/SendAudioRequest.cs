using System.Collections.Generic;
using System.Net.Http;
using Telegram.Bot.Extensions;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send audio files, if you want Telegram clients to display them in the music
/// player. Your audio must be in the .MP3 or .M4A format. On success, the sent <see cref="Message"/>
/// is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be
/// changed in the future.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="audio">
/// Audio file to send. Pass a <see cref="InputFileId"/> as String to send an audio
/// file that exists on the Telegram servers (recommended), pass an HTTP URL as a String for
/// Telegram to get an audio file from the Internet, or upload a new one using multipart/form-data
/// </param>
public class SendAudioRequest(ChatId chatId, InputFile audio)
    : FileRequestBase<Message>("sendAudio"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Audio file to send. Pass a <see cref="InputFileId"/> as String to send an audio
    /// file that exists on the Telegram servers (recommended), pass an HTTP URL as a String for
    /// Telegram to get an audio file from the Internet, or upload a new one using multipart/form-data
    /// </summary>
    public InputFile Audio { get; } = audio;

    /// <summary>
    /// Audio caption, 0-1024 characters after entities parsing
    /// </summary>
    public string? Caption { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ParseMode"/>
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.CaptionEntities"/>
    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    /// <summary>
    /// Duration of the audio in seconds
    /// </summary>
    public int? Duration { get; set; }

    /// <summary>
    /// Performer
    /// </summary>
    public string? Performer { get; set; }

    /// <summary>
    /// Track name
    /// </summary>
    public string? Title { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.Thumbnail"/>
    public InputFile? Thumbnail { get; set; }

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
        Audio is InputFileStream || Thumbnail is InputFileStream
            ? GenerateMultipartFormDataContent("audio", "thumbnail")
                .AddContentIfInputFile(media: Audio, name: "audio")
                .AddContentIfInputFile(media: Thumbnail, name: "thumbnail")
            : base.ToHttpContent();
}
