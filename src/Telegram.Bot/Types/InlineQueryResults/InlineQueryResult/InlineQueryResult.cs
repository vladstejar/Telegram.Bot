using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Base Class for inline results send in response to an <see cref="InlineQuery"/>
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#else
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(InlineQueryResultArticle))]
[JsonDerivedType(typeof(InlineQueryResultAudio))]
[JsonDerivedType(typeof(InlineQueryResultCachedAudio))]
[JsonDerivedType(typeof(InlineQueryResultCachedDocument))]
[JsonDerivedType(typeof(InlineQueryResultCachedGif))]
[JsonDerivedType(typeof(InlineQueryResultCachedMpeg4Gif))]
[JsonDerivedType(typeof(InlineQueryResultCachedPhoto))]
[JsonDerivedType(typeof(InlineQueryResultCachedSticker))]
[JsonDerivedType(typeof(InlineQueryResultCachedVideo))]
[JsonDerivedType(typeof(InlineQueryResultCachedVoice))]
[JsonDerivedType(typeof(InlineQueryResultContact))]
[JsonDerivedType(typeof(InlineQueryResultDocument))]
[JsonDerivedType(typeof(InlineQueryResultGame))]
[JsonDerivedType(typeof(InlineQueryResultGif))]
[JsonDerivedType(typeof(InlineQueryResultLocation))]
[JsonDerivedType(typeof(InlineQueryResultMpeg4Gif))]
[JsonDerivedType(typeof(InlineQueryResultPhoto))]
[JsonDerivedType(typeof(InlineQueryResultVenue))]
[JsonDerivedType(typeof(InlineQueryResultVideo))]
[JsonDerivedType(typeof(InlineQueryResultVoice))]
#endif
public abstract class InlineQueryResult
{
    /// <summary>
    /// Type of the result
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public abstract InlineQueryResultType Type { get; }

    /// <summary>
    /// Unique identifier for this result, 1-64 Bytes
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Id { get; }

    /// <summary>
    /// Optional. Inline keyboard attached to the message
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new inline query result
    /// </summary>
    /// <param name="id">Unique identifier for this result, 1-64 Bytes</param>
    protected InlineQueryResult(string id) => Id = id;
}
