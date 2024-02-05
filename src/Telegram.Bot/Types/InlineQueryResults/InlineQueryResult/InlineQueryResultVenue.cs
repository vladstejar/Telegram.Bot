

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a venue. By default, the venue will be sent by the user. Alternatively, you can use
/// <see cref="InlineQueryResultVenue.InputMessageContent"/> to send a message with the specified
/// content instead of the venue.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InlineQueryResultVenue : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be venue
    /// </summary>
    [DataMember(IsRequired = true)]
    public override InlineQueryResultType Type => InlineQueryResultType.Venue;

    /// <inheritdoc cref="Documentation.Latitude" />
    [DataMember(IsRequired = true)]
    public double Latitude { get; }

    /// <inheritdoc cref="Documentation.Longitude" />
    [DataMember(IsRequired = true)]
    public double Longitude { get; }

    /// <summary>
    /// Title of the venue
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Title { get; }

    /// <summary>
    /// Address of the venue
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Address { get; }

    /// <summary>
    /// Optional. Foursquare identifier of the venue if known
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? FoursquareId { get; set; }

    /// <summary>
    /// Optional. Foursquare type of the venue. (For example, "arts_entertainment/default",
    /// "arts_entertainment/aquarium" or "food/icecream".)
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? FoursquareType { get; set; }

    /// <summary>
    /// Google Places identifier of the venue
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? GooglePlaceId { get; set; }

    /// <summary>
    /// Google Places type of the venue.
    /// <a href="https://developers.google.com/places/web-service/supported_types"/>
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? GooglePlaceType { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    [DataMember(EmitDefaultValue = false)]
    public InputMessageContent? InputMessageContent { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailUrl" />
    [DataMember(EmitDefaultValue = false)]
    public string? ThumbnailUrl { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailWidth" />
    [DataMember(EmitDefaultValue = false)]
    public int? ThumbnailWidth { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailHeight" />
    [DataMember(EmitDefaultValue = false)]
    public int? ThumbnailHeight { get; set; }

    /// <summary>
    /// Initializes a new inline query result
    /// </summary>
    /// <param name="id">Unique identifier of this result</param>
    /// <param name="latitude">Latitude of the location in degrees</param>
    /// <param name="longitude">Longitude of the location in degrees</param>
    /// <param name="title">Title of the result</param>
    /// <param name="address">Address of the venue</param>
    public InlineQueryResultVenue(
        string id,
        double latitude,
        double longitude,
        string title,
        string address) : base(id)
    {
        Latitude = latitude;
        Longitude = longitude;
        Title = title;
        Address = address;
    }
}
