﻿namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send video files, Telegram clients support MPEG4 videos (other formats may be sent as <see cref="Document"/>).<para>Returns: The sent <see cref="Message"/> is returned.</para>
/// </summary>
/// <remarks>
/// Bots can currently send video files of up to 50 MB in size, this limit may be changed in the future.
/// </remarks>
public partial class SendVideoRequest : FileRequestBase<Message>, IChatTargetable, IBusinessConnectable
{
    /// <summary>
    /// Unique identifier for the target chat or username of the target channel (in the format <c>@channelusername</c>)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; set; }

    /// <summary>
    /// Video to send. Pass a FileId as String to send a video that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to get a video from the Internet, or upload a new video using <see cref="InputFileStream"/>. <a href="https://core.telegram.org/bots/api#sending-files">More information on Sending Files »</a>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required InputFile Video { get; set; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Duration of sent video in seconds
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Duration { get; set; }

    /// <summary>
    /// Video width
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Width { get; set; }

    /// <summary>
    /// Video height
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Height { get; set; }

    /// <summary>
    /// Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side. The thumbnail should be in JPEG format and less than 200 kB in size. A thumbnail's width and height should not exceed 320. Ignored if the file is not uploaded using <see cref="InputFileStream"/>. Thumbnails can't be reused and can be only uploaded as a new file, so you can pass “attach://&lt;FileAttachName&gt;” if the thumbnail was uploaded using <see cref="InputFileStream"/> under &lt;FileAttachName&gt;. <a href="https://core.telegram.org/bots/api#sending-files">More information on Sending Files »</a>
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public InputFile? Thumbnail { get; set; }

    /// <summary>
    /// Video caption (may also be used when resending videos by <em>FileId</em>), 0-1024 characters after entities parsing
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Caption { get; set; }

    /// <summary>
    /// Mode for parsing entities in the video caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ParseMode ParseMode { get; set; }

    /// <summary>
    /// A list of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see>
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the caption must be shown above the message media
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the video needs to be covered with a spoiler animation
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool HasSpoiler { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the uploaded video is suitable for streaming
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool SupportsStreaming { get; set; }

    /// <summary>
    /// Sends the message <a href="https://telegram.org/blog/channels-2-0#silent-messages">silently</a>. Users will receive a notification with no sound.
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool DisableNotification { get; set; }

    /// <summary>
    /// Protects the contents of the sent message from forwarding and saving
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ProtectContent { get; set; }

    /// <summary>
    /// Unique identifier of the message effect to be added to the message; for private chats only
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MessageEffectId { get; set; }

    /// <summary>
    /// Description of the message to reply to
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReplyParameters? ReplyParameters { get; set; }

    /// <summary>
    /// Additional interface options. An object for an <a href="https://core.telegram.org/bots/features#inline-keyboards">inline keyboard</a>, <a href="https://core.telegram.org/bots/features#keyboards">custom reply keyboard</a>, instructions to remove a reply keyboard or to force a reply from the user
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReplyMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Unique identifier of the business connection on behalf of which the message will be sent
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BusinessConnectionId { get; set; }

    /// <summary>
    /// Initializes an instance of <see cref="SendVideoRequest"/>
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format <c>@channelusername</c>)</param>
    /// <param name="video">Video to send. Pass a FileId as String to send a video that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to get a video from the Internet, or upload a new video using <see cref="InputFileStream"/>. <a href="https://core.telegram.org/bots/api#sending-files">More information on Sending Files »</a></param>
    [Obsolete("Use parameterless constructor with required properties")]
    [SetsRequiredMembers]
    public SendVideoRequest(ChatId chatId, InputFile video)
        : this()
    {
        ChatId = chatId;
        Video = video;
    }

    /// <summary>
    /// Instantiates a new <see cref="SendVideoRequest"/>
    /// </summary>
    public SendVideoRequest()
        : base("sendVideo")
    { }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent()
        => Video is InputFileStream || Thumbnail is InputFileStream
            ? GenerateMultipartFormDataContent("video", "thumbnail")
                .AddContentIfInputFile(media: Video, name: "video")
                .AddContentIfInputFile(media: Thumbnail, name: "thumbnail")
            : base.ToHttpContent();
}
