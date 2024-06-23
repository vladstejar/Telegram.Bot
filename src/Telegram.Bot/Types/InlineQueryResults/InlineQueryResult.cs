﻿namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>This object represents one result of an inline query. Telegram clients currently support results of the following 20 types:<br/><see cref="InlineQueryResultCachedAudio"/>, <see cref="InlineQueryResultCachedDocument"/>, <see cref="InlineQueryResultCachedGif"/>, <see cref="InlineQueryResultCachedMpeg4Gif"/>, <see cref="InlineQueryResultCachedPhoto"/>, <see cref="InlineQueryResultCachedSticker"/>, <see cref="InlineQueryResultCachedVideo"/>, <see cref="InlineQueryResultCachedVoice"/>, <see cref="InlineQueryResultArticle"/>, <see cref="InlineQueryResultAudio"/>, <see cref="InlineQueryResultContact"/>, <see cref="InlineQueryResultGame"/>, <see cref="InlineQueryResultDocument"/>, <see cref="InlineQueryResultGif"/>, <see cref="InlineQueryResultLocation"/>, <see cref="InlineQueryResultMpeg4Gif"/>, <see cref="InlineQueryResultPhoto"/>, <see cref="InlineQueryResultVenue"/>, <see cref="InlineQueryResultVideo"/>, <see cref="InlineQueryResultVoice"/><br/><b>Note:</b> All URLs passed in inline query results will be available to end users and therefore must be assumed to be <b>public</b>.</summary>
[CustomJsonPolymorphic("type")]
[CustomJsonDerivedType(typeof(InlineQueryResultArticle), "article")]
[CustomJsonDerivedType(typeof(InlineQueryResultAudio), "audio")]
[CustomJsonDerivedType(typeof(InlineQueryResultContact), "contact")]
[CustomJsonDerivedType(typeof(InlineQueryResultGame), "game")]
[CustomJsonDerivedType(typeof(InlineQueryResultDocument), "document")]
[CustomJsonDerivedType(typeof(InlineQueryResultGif), "gif")]
[CustomJsonDerivedType(typeof(InlineQueryResultLocation), "location")]
[CustomJsonDerivedType(typeof(InlineQueryResultMpeg4Gif), "mpeg4_gif")]
[CustomJsonDerivedType(typeof(InlineQueryResultPhoto), "photo")]
[CustomJsonDerivedType(typeof(InlineQueryResultVenue), "venue")]
[CustomJsonDerivedType(typeof(InlineQueryResultVideo), "video")]
[CustomJsonDerivedType(typeof(InlineQueryResultVoice), "voice")]
[CustomJsonDerivedType(typeof(InlineQueryResultCachedSticker), "sticker")]
public abstract partial class InlineQueryResult
{
    /// <summary>Type of the result</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public abstract InlineQueryResultType Type { get; }

    /// <summary>Unique identifier for this result, 1-64 bytes</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Id { get; set; }

    /// <summary><em>Optional</em>. <a href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</a> attached to the message</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResult"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    protected InlineQueryResult(string id) => Id = id;

    /// <summary>Instantiates a new <see cref="InlineQueryResult"/></summary>
    protected InlineQueryResult() { }
}

/// <summary>Represents a link to an article or web page.</summary>
public partial class InlineQueryResultArticle : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Article"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Article;

    /// <summary>Title of the result</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Title { get; set; }

    /// <summary>Content of the message to be sent</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required InputMessageContent InputMessageContent { get; set; }

    /// <summary><em>Optional</em>. URL of the result</summary>
    public string? Url { get; set; }

    /// <summary><em>Optional</em>. Pass <see langword="true"/> if you don't want the URL to be shown in the message</summary>
    public bool HideUrl { get; set; }

    /// <summary><em>Optional</em>. Short description of the result</summary>
    public string? Description { get; set; }

    /// <summary><em>Optional</em>. Url of the thumbnail for the result</summary>
    public string? ThumbnailUrl { get; set; }

    /// <summary><em>Optional</em>. Thumbnail width</summary>
    public int? ThumbnailWidth { get; set; }

    /// <summary><em>Optional</em>. Thumbnail height</summary>
    public int? ThumbnailHeight { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultArticle"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="title">Title of the result</param>
    /// <param name="inputMessageContent">Content of the message to be sent</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultArticle(string id, string title, InputMessageContent inputMessageContent) : base(id)
    {
        Title = title;
        InputMessageContent = inputMessageContent;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultArticle"/></summary>
    public InlineQueryResultArticle() { }
}

/// <summary>Represents a link to a photo. By default, this photo will be sent by the user with optional caption. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the photo.</summary>
public partial class InlineQueryResultPhoto : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Photo"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Photo;

    /// <summary>A valid URL of the photo. Photo must be in <b>JPEG</b> format. Photo size must not exceed 5MB</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string PhotoUrl { get; set; }

    /// <summary>URL of the thumbnail for the photo</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string ThumbnailUrl { get; set; }

    /// <summary><em>Optional</em>. Width of the photo</summary>
    public int? PhotoWidth { get; set; }

    /// <summary><em>Optional</em>. Height of the photo</summary>
    public int? PhotoHeight { get; set; }

    /// <summary><em>Optional</em>. Title for the result</summary>
    public string? Title { get; set; }

    /// <summary><em>Optional</em>. Short description of the result</summary>
    public string? Description { get; set; }

    /// <summary><em>Optional</em>. Caption of the photo to be sent, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the photo caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Pass <see langword="true"/>, if the caption must be shown above the message media</summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the photo</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultPhoto"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="photoUrl">A valid URL of the photo. Photo must be in <b>JPEG</b> format. Photo size must not exceed 5MB</param>
    /// <param name="thumbnailUrl">URL of the thumbnail for the photo</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultPhoto(string id, string photoUrl, string thumbnailUrl) : base(id)
    {
        PhotoUrl = photoUrl;
        ThumbnailUrl = thumbnailUrl;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultPhoto"/></summary>
    public InlineQueryResultPhoto() { }
}

/// <summary>Represents a link to an animated GIF file. By default, this animated GIF file will be sent by the user with optional caption. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the animation.</summary>
public partial class InlineQueryResultGif : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Gif"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Gif;

    /// <summary>A valid URL for the GIF file. File size must not exceed 1MB</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string GifUrl { get; set; }

    /// <summary><em>Optional</em>. Width of the GIF</summary>
    public int? GifWidth { get; set; }

    /// <summary><em>Optional</em>. Height of the GIF</summary>
    public int? GifHeight { get; set; }

    /// <summary><em>Optional</em>. Duration of the GIF in seconds</summary>
    public int? GifDuration { get; set; }

    /// <summary>URL of the static (JPEG or GIF) or animated (MPEG4) thumbnail for the result</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string ThumbnailUrl { get; set; }

    /// <summary><em>Optional</em>. MIME type of the thumbnail, must be one of “image/jpeg”, “image/gif”, or “video/mp4”. Defaults to “image/jpeg”</summary>
    public string? ThumbnailMimeType { get; set; }

    /// <summary><em>Optional</em>. Title for the result</summary>
    public string? Title { get; set; }

    /// <summary><em>Optional</em>. Caption of the GIF file to be sent, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Pass <see langword="true"/>, if the caption must be shown above the message media</summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the GIF animation</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultGif"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="gifUrl">A valid URL for the GIF file. File size must not exceed 1MB</param>
    /// <param name="thumbnailUrl">URL of the static (JPEG or GIF) or animated (MPEG4) thumbnail for the result</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultGif(string id, string gifUrl, string thumbnailUrl) : base(id)
    {
        GifUrl = gifUrl;
        ThumbnailUrl = thumbnailUrl;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultGif"/></summary>
    public InlineQueryResultGif() { }
}

/// <summary>Represents a link to a video animation (H.264/MPEG-4 AVC video without sound). By default, this animated MPEG-4 file will be sent by the user with optional caption. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the animation.</summary>
public partial class InlineQueryResultMpeg4Gif : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Mpeg4Gif"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Mpeg4Gif;

    /// <summary>A valid URL for the MPEG4 file. File size must not exceed 1MB</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Mpeg4Url { get; set; }

    /// <summary><em>Optional</em>. Video width</summary>
    public int? Mpeg4Width { get; set; }

    /// <summary><em>Optional</em>. Video height</summary>
    public int? Mpeg4Height { get; set; }

    /// <summary><em>Optional</em>. Video duration in seconds</summary>
    public int? Mpeg4Duration { get; set; }

    /// <summary>URL of the static (JPEG or GIF) or animated (MPEG4) thumbnail for the result</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string ThumbnailUrl { get; set; }

    /// <summary><em>Optional</em>. MIME type of the thumbnail, must be one of “image/jpeg”, “image/gif”, or “video/mp4”. Defaults to “image/jpeg”</summary>
    public string? ThumbnailMimeType { get; set; }

    /// <summary><em>Optional</em>. Title for the result</summary>
    public string? Title { get; set; }

    /// <summary><em>Optional</em>. Caption of the MPEG-4 file to be sent, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Pass <see langword="true"/>, if the caption must be shown above the message media</summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the video animation</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultMpeg4Gif"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="mpeg4Url">A valid URL for the MPEG4 file. File size must not exceed 1MB</param>
    /// <param name="thumbnailUrl">URL of the static (JPEG or GIF) or animated (MPEG4) thumbnail for the result</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultMpeg4Gif(string id, string mpeg4Url, string thumbnailUrl) : base(id)
    {
        Mpeg4Url = mpeg4Url;
        ThumbnailUrl = thumbnailUrl;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultMpeg4Gif"/></summary>
    public InlineQueryResultMpeg4Gif() { }
}

/// <summary>Represents a link to a page containing an embedded video player or a video file. By default, this video file will be sent by the user with an optional caption. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the video.</summary>
/// <remarks>If an InlineQueryResultVideo message contains an embedded video (e.g., YouTube), you <b>must</b> replace its content using <see cref="InputMessageContent">InputMessageContent</see>.</remarks>
public partial class InlineQueryResultVideo : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Video"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Video;

    /// <summary>A valid URL for the embedded video player or video file</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string VideoUrl { get; set; }

    /// <summary>MIME type of the content of the video URL, “text/html” or “video/mp4”</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string MimeType { get; set; }

    /// <summary>URL of the thumbnail (JPEG only) for the video</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string ThumbnailUrl { get; set; }

    /// <summary>Title for the result</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Title { get; set; }

    /// <summary><em>Optional</em>. Caption of the video to be sent, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the video caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Pass <see langword="true"/>, if the caption must be shown above the message media</summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary><em>Optional</em>. Video width</summary>
    public int? VideoWidth { get; set; }

    /// <summary><em>Optional</em>. Video height</summary>
    public int? VideoHeight { get; set; }

    /// <summary><em>Optional</em>. Video duration in seconds</summary>
    public int? VideoDuration { get; set; }

    /// <summary><em>Optional</em>. Short description of the result</summary>
    public string? Description { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the video. This field is <b>required</b> if InlineQueryResultVideo is used to send an HTML-page as a result (e.g., a YouTube video).</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultVideo"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="videoUrl">A valid URL for the embedded video player or video file</param>
    /// <param name="thumbnailUrl">URL of the thumbnail (JPEG only) for the video</param>
    /// <param name="title">Title for the result</param>
    /// <param name="inputMessageContent"><em>Optional</em>. Content of the message to be sent instead of the video. This field is <b>required</b> if InlineQueryResultVideo is used to send an HTML-page as a result (e.g., a YouTube video).</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultVideo(string id, string videoUrl, string thumbnailUrl, string title, InputMessageContent? inputMessageContent = default) : base(id)
    {
        VideoUrl = videoUrl;
        ThumbnailUrl = thumbnailUrl;
        Title = title;
        InputMessageContent = inputMessageContent;
        MimeType = inputMessageContent is null ? "video/mp4" : "text/html";
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultVideo"/></summary>
    public InlineQueryResultVideo() { }
}

/// <summary>Represents a link to an MP3 audio file. By default, this audio file will be sent by the user. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the audio.</summary>
public partial class InlineQueryResultAudio : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Audio"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Audio;

    /// <summary>A valid URL for the audio file</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string AudioUrl { get; set; }

    /// <summary>Title</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Title { get; set; }

    /// <summary><em>Optional</em>. Caption, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the audio caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Performer</summary>
    public string? Performer { get; set; }

    /// <summary><em>Optional</em>. Audio duration in seconds</summary>
    public int? AudioDuration { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the audio</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultAudio"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="audioUrl">A valid URL for the audio file</param>
    /// <param name="title">Title</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultAudio(string id, string audioUrl, string title) : base(id)
    {
        AudioUrl = audioUrl;
        Title = title;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultAudio"/></summary>
    public InlineQueryResultAudio() { }
}

/// <summary>Represents a link to a voice recording in an .OGG container encoded with OPUS. By default, this voice recording will be sent by the user. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the the voice message.</summary>
public partial class InlineQueryResultVoice : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Voice"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Voice;

    /// <summary>A valid URL for the voice recording</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string VoiceUrl { get; set; }

    /// <summary>Recording title</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Title { get; set; }

    /// <summary><em>Optional</em>. Caption, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the voice message caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Recording duration in seconds</summary>
    public int? VoiceDuration { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the voice recording</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultVoice"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="voiceUrl">A valid URL for the voice recording</param>
    /// <param name="title">Recording title</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultVoice(string id, string voiceUrl, string title) : base(id)
    {
        VoiceUrl = voiceUrl;
        Title = title;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultVoice"/></summary>
    public InlineQueryResultVoice() { }
}

/// <summary>Represents a link to a file. By default, this file will be sent by the user with an optional caption. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the file. Currently, only <b>.PDF</b> and <b>.ZIP</b> files can be sent using this method.</summary>
public partial class InlineQueryResultDocument : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Document"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Document;

    /// <summary>A valid URL for the file</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string DocumentUrl { get; set; }

    /// <summary>Title for the result</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Title { get; set; }

    /// <summary><em>Optional</em>. Caption of the document to be sent, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the document caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary>MIME type of the content of the file, either “application/pdf” or “application/zip”</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string MimeType { get; set; }

    /// <summary><em>Optional</em>. Short description of the result</summary>
    public string? Description { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the file</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary><em>Optional</em>. URL of the thumbnail (JPEG only) for the file</summary>
    public string? ThumbnailUrl { get; set; }

    /// <summary><em>Optional</em>. Thumbnail width</summary>
    public int? ThumbnailWidth { get; set; }

    /// <summary><em>Optional</em>. Thumbnail height</summary>
    public int? ThumbnailHeight { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultDocument"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="documentUrl">A valid URL for the file</param>
    /// <param name="title">Title for the result</param>
    /// <param name="mimeType">MIME type of the content of the file, either “application/pdf” or “application/zip”</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultDocument(string id, string documentUrl, string title, string mimeType) : base(id)
    {
        DocumentUrl = documentUrl;
        Title = title;
        MimeType = mimeType;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultDocument"/></summary>
    public InlineQueryResultDocument() { }
}

/// <summary>Represents a location on a map. By default, the location will be sent by the user. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the location.</summary>
public partial class InlineQueryResultLocation : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Location"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Location;

    /// <summary>Location latitude in degrees</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required double Latitude { get; set; }

    /// <summary>Location longitude in degrees</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required double Longitude { get; set; }

    /// <summary>Location title</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Title { get; set; }

    /// <summary><em>Optional</em>. The radius of uncertainty for the location, measured in meters; 0-1500</summary>
    public double? HorizontalAccuracy { get; set; }

    /// <summary><em>Optional</em>. Period in seconds during which the location can be updated, should be between 60 and 86400, or 0x7FFFFFFF for live locations that can be edited indefinitely.</summary>
    public int? LivePeriod { get; set; }

    /// <summary><em>Optional</em>. For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.</summary>
    public int? Heading { get; set; }

    /// <summary><em>Optional</em>. For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified.</summary>
    public int? ProximityAlertRadius { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the location</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary><em>Optional</em>. Url of the thumbnail for the result</summary>
    public string? ThumbnailUrl { get; set; }

    /// <summary><em>Optional</em>. Thumbnail width</summary>
    public int? ThumbnailWidth { get; set; }

    /// <summary><em>Optional</em>. Thumbnail height</summary>
    public int? ThumbnailHeight { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultLocation"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="latitude">Location latitude in degrees</param>
    /// <param name="longitude">Location longitude in degrees</param>
    /// <param name="title">Location title</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultLocation(string id, double latitude, double longitude, string title) : base(id)
    {
        Latitude = latitude;
        Longitude = longitude;
        Title = title;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultLocation"/></summary>
    public InlineQueryResultLocation() { }
}

/// <summary>Represents a venue. By default, the venue will be sent by the user. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the venue.</summary>
public partial class InlineQueryResultVenue : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Venue"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Venue;

    /// <summary>Latitude of the venue location in degrees</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required double Latitude { get; set; }

    /// <summary>Longitude of the venue location in degrees</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required double Longitude { get; set; }

    /// <summary>Title of the venue</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Title { get; set; }

    /// <summary>Address of the venue</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Address { get; set; }

    /// <summary><em>Optional</em>. Foursquare identifier of the venue if known</summary>
    public string? FoursquareId { get; set; }

    /// <summary><em>Optional</em>. Foursquare type of the venue, if known. (For example, “arts_entertainment/default”, “arts_entertainment/aquarium” or “food/icecream”.)</summary>
    public string? FoursquareType { get; set; }

    /// <summary><em>Optional</em>. Google Places identifier of the venue</summary>
    public string? GooglePlaceId { get; set; }

    /// <summary><em>Optional</em>. Google Places type of the venue. (See <a href="https://developers.google.com/places/web-service/supported_types">supported types</a>.)</summary>
    public string? GooglePlaceType { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the venue</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary><em>Optional</em>. Url of the thumbnail for the result</summary>
    public string? ThumbnailUrl { get; set; }

    /// <summary><em>Optional</em>. Thumbnail width</summary>
    public int? ThumbnailWidth { get; set; }

    /// <summary><em>Optional</em>. Thumbnail height</summary>
    public int? ThumbnailHeight { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultVenue"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="latitude">Latitude of the venue location in degrees</param>
    /// <param name="longitude">Longitude of the venue location in degrees</param>
    /// <param name="title">Title of the venue</param>
    /// <param name="address">Address of the venue</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultVenue(string id, double latitude, double longitude, string title, string address) : base(id)
    {
        Latitude = latitude;
        Longitude = longitude;
        Title = title;
        Address = address;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultVenue"/></summary>
    public InlineQueryResultVenue() { }
}

/// <summary>Represents a contact with a phone number. By default, this contact will be sent by the user. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the contact.</summary>
public partial class InlineQueryResultContact : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Contact"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Contact;

    /// <summary>Contact's phone number</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string PhoneNumber { get; set; }

    /// <summary>Contact's first name</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string FirstName { get; set; }

    /// <summary><em>Optional</em>. Contact's last name</summary>
    public string? LastName { get; set; }

    /// <summary><em>Optional</em>. Additional data about the contact in the form of a <a href="https://en.wikipedia.org/wiki/VCard">vCard</a>, 0-2048 bytes</summary>
    public string? Vcard { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the contact</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary><em>Optional</em>. Url of the thumbnail for the result</summary>
    public string? ThumbnailUrl { get; set; }

    /// <summary><em>Optional</em>. Thumbnail width</summary>
    public int? ThumbnailWidth { get; set; }

    /// <summary><em>Optional</em>. Thumbnail height</summary>
    public int? ThumbnailHeight { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultContact"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="phoneNumber">Contact's phone number</param>
    /// <param name="firstName">Contact's first name</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultContact(string id, string phoneNumber, string firstName) : base(id)
    {
        PhoneNumber = phoneNumber;
        FirstName = firstName;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultContact"/></summary>
    public InlineQueryResultContact() { }
}

/// <summary>Represents a <a href="https://core.telegram.org/bots/api#games">Game</a>.</summary>
public partial class InlineQueryResultGame : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Game"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Game;

    /// <summary>Short name of the game</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string GameShortName { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultGame"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="gameShortName">Short name of the game</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultGame(string id, string gameShortName) : base(id) => GameShortName = gameShortName;

    /// <summary>Instantiates a new <see cref="InlineQueryResultGame"/></summary>
    public InlineQueryResultGame() { }
}

/// <summary>Represents a link to a photo stored on the Telegram servers. By default, this photo will be sent by the user with an optional caption. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the photo.</summary>
public partial class InlineQueryResultCachedPhoto : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Photo"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Photo;

    /// <summary>A valid file identifier of the photo</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string PhotoFileId { get; set; }

    /// <summary><em>Optional</em>. Title for the result</summary>
    public string? Title { get; set; }

    /// <summary><em>Optional</em>. Short description of the result</summary>
    public string? Description { get; set; }

    /// <summary><em>Optional</em>. Caption of the photo to be sent, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the photo caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Pass <see langword="true"/>, if the caption must be shown above the message media</summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the photo</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultCachedPhoto"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="photoFileId">A valid file identifier of the photo</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultCachedPhoto(string id, string photoFileId) : base(id) => PhotoFileId = photoFileId;

    /// <summary>Instantiates a new <see cref="InlineQueryResultCachedPhoto"/></summary>
    public InlineQueryResultCachedPhoto() { }
}

/// <summary>Represents a link to an animated GIF file stored on the Telegram servers. By default, this animated GIF file will be sent by the user with an optional caption. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with specified content instead of the animation.</summary>
public partial class InlineQueryResultCachedGif : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Gif"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Gif;

    /// <summary>A valid file identifier for the GIF file</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string GifFileId { get; set; }

    /// <summary><em>Optional</em>. Title for the result</summary>
    public string? Title { get; set; }

    /// <summary><em>Optional</em>. Caption of the GIF file to be sent, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Pass <see langword="true"/>, if the caption must be shown above the message media</summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the GIF animation</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultCachedGif"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="gifFileId">A valid file identifier for the GIF file</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultCachedGif(string id, string gifFileId) : base(id) => GifFileId = gifFileId;

    /// <summary>Instantiates a new <see cref="InlineQueryResultCachedGif"/></summary>
    public InlineQueryResultCachedGif() { }
}

/// <summary>Represents a link to a video animation (H.264/MPEG-4 AVC video without sound) stored on the Telegram servers. By default, this animated MPEG-4 file will be sent by the user with an optional caption. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the animation.</summary>
public partial class InlineQueryResultCachedMpeg4Gif : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Mpeg4Gif"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Mpeg4Gif;

    /// <summary>A valid file identifier for the MPEG4 file</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Mpeg4FileId { get; set; }

    /// <summary><em>Optional</em>. Title for the result</summary>
    public string? Title { get; set; }

    /// <summary><em>Optional</em>. Caption of the MPEG-4 file to be sent, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Pass <see langword="true"/>, if the caption must be shown above the message media</summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the video animation</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultCachedMpeg4Gif"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="mpeg4FileId">A valid file identifier for the MPEG4 file</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultCachedMpeg4Gif(string id, string mpeg4FileId) : base(id) => Mpeg4FileId = mpeg4FileId;

    /// <summary>Instantiates a new <see cref="InlineQueryResultCachedMpeg4Gif"/></summary>
    public InlineQueryResultCachedMpeg4Gif() { }
}

/// <summary>Represents a link to a sticker stored on the Telegram servers. By default, this sticker will be sent by the user. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the sticker.</summary>
public partial class InlineQueryResultCachedSticker : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Sticker"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Sticker;

    /// <summary>A valid file identifier of the sticker</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string StickerFileId { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the sticker</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultCachedSticker"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="stickerFileId">A valid file identifier of the sticker</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultCachedSticker(string id, string stickerFileId) : base(id) => StickerFileId = stickerFileId;

    /// <summary>Instantiates a new <see cref="InlineQueryResultCachedSticker"/></summary>
    public InlineQueryResultCachedSticker() { }
}

/// <summary>Represents a link to a file stored on the Telegram servers. By default, this file will be sent by the user with an optional caption. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the file.</summary>
public partial class InlineQueryResultCachedDocument : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Document"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Document;

    /// <summary>A valid file identifier for the file</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string DocumentFileId { get; set; }

    /// <summary>Title for the result</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Title { get; set; }

    /// <summary><em>Optional</em>. Short description of the result</summary>
    public string? Description { get; set; }

    /// <summary><em>Optional</em>. Caption of the document to be sent, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the document caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the file</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultCachedDocument"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="documentFileId">A valid file identifier for the file</param>
    /// <param name="title">Title for the result</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultCachedDocument(string id, string documentFileId, string title) : base(id)
    {
        DocumentFileId = documentFileId;
        Title = title;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultCachedDocument"/></summary>
    public InlineQueryResultCachedDocument() { }
}

/// <summary>Represents a link to a video file stored on the Telegram servers. By default, this video file will be sent by the user with an optional caption. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the video.</summary>
public partial class InlineQueryResultCachedVideo : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Video"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Video;

    /// <summary>A valid file identifier for the video file</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string VideoFileId { get; set; }

    /// <summary>Title for the result</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Title { get; set; }

    /// <summary><em>Optional</em>. Short description of the result</summary>
    public string? Description { get; set; }

    /// <summary><em>Optional</em>. Caption of the video to be sent, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the video caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Pass <see langword="true"/>, if the caption must be shown above the message media</summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the video</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultCachedVideo"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="videoFileId">A valid file identifier for the video file</param>
    /// <param name="title">Title for the result</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultCachedVideo(string id, string videoFileId, string title) : base(id)
    {
        VideoFileId = videoFileId;
        Title = title;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultCachedVideo"/></summary>
    public InlineQueryResultCachedVideo() { }
}

/// <summary>Represents a link to a voice message stored on the Telegram servers. By default, this voice message will be sent by the user. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the voice message.</summary>
public partial class InlineQueryResultCachedVoice : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Voice"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Voice;

    /// <summary>A valid file identifier for the voice message</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string VoiceFileId { get; set; }

    /// <summary>Voice message title</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Title { get; set; }

    /// <summary><em>Optional</em>. Caption, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the voice message caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the voice message</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultCachedVoice"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="voiceFileId">A valid file identifier for the voice message</param>
    /// <param name="title">Voice message title</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultCachedVoice(string id, string voiceFileId, string title) : base(id)
    {
        VoiceFileId = voiceFileId;
        Title = title;
    }

    /// <summary>Instantiates a new <see cref="InlineQueryResultCachedVoice"/></summary>
    public InlineQueryResultCachedVoice() { }
}

/// <summary>Represents a link to an MP3 audio file stored on the Telegram servers. By default, this audio file will be sent by the user. Alternatively, you can use <see cref="InputMessageContent">InputMessageContent</see> to send a message with the specified content instead of the audio.</summary>
public partial class InlineQueryResultCachedAudio : InlineQueryResult
{
    /// <summary>Type of the result, always <see cref="InlineQueryResultType.Audio"/></summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Audio;

    /// <summary>A valid file identifier for the audio file</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string AudioFileId { get; set; }

    /// <summary><em>Optional</em>. Caption, 0-1024 characters after entities parsing</summary>
    public string? Caption { get; set; }

    /// <summary><em>Optional</em>. Mode for parsing entities in the audio caption. See <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a> for more details.</summary>
    public ParseMode ParseMode { get; set; }

    /// <summary><em>Optional</em>. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode">ParseMode</see></summary>
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary><em>Optional</em>. Content of the message to be sent instead of the audio</summary>
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>Initializes an instance of <see cref="InlineQueryResultCachedAudio"/></summary>
    /// <param name="id">Unique identifier for this result, 1-64 bytes</param>
    /// <param name="audioFileId">A valid file identifier for the audio file</param>
    [JsonConstructor]
    [SetsRequiredMembers]
    public InlineQueryResultCachedAudio(string id, string audioFileId) : base(id) => AudioFileId = audioFileId;

    /// <summary>Instantiates a new <see cref="InlineQueryResultCachedAudio"/></summary>
    public InlineQueryResultCachedAudio() { }
}
