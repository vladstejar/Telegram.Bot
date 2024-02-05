using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to an animated GIF file stored on the Telegram servers. By default, this
/// animated GIF file will be sent by the user with an optional caption. Alternatively, you can
/// use <see cref="InlineQueryResultCachedGif.InputMessageContent"/> to send a message with
/// specified content instead of the animation.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InlineQueryResultCachedGif : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be GIF
    /// </summary>
    [DataMember(IsRequired = true)]
    public override InlineQueryResultType Type => InlineQueryResultType.Gif;

    /// <summary>
    /// A valid file identifier for the GIF file
    /// </summary>
    [DataMember(IsRequired = true)]
    public string GifFileId { get; }

    /// <summary>
    /// Optional. Title for the result
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Title { get; set; }

    /// <inheritdoc cref="Documentation.Caption" />
    [DataMember(EmitDefaultValue = false)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    [DataMember(EmitDefaultValue = false)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    [DataMember(EmitDefaultValue = false)]
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    [DataMember(EmitDefaultValue = false)]
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>
    /// Initializes a new inline query result
    /// </summary>
    /// <param name="id">Unique identifier of this result</param>
    /// <param name="gifFileId">A valid file identifier for the GIF file</param>
    public InlineQueryResultCachedGif(string id, string gifFileId)
        : base(id)
    {
        GifFileId = gifFileId;
    }
}
