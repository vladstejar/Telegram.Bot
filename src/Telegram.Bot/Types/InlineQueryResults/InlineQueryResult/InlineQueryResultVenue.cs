using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a venue. By default, the venue will be sent by the user. Alternatively, you can use
/// <see cref="InlineQueryResultVenue.InputMessageContent"/> to send a message with the specified
/// content instead of the venue.
/// </summary>
/// <param name="id">Unique identifier of this result</param>
/// <param name="latitude">Latitude of the location in degrees</param>
/// <param name="longitude">Longitude of the location in degrees</param>
/// <param name="title">Title of the result</param>
/// <param name="address">Address of the venue</param>
[PublicAPI]
public class InlineQueryResultVenue(
    string id,
    double latitude,
    double longitude,
    string title,
    string address)
        : InlineQueryResult(id)
{
    /// <summary>
    /// Type of the result, must be venue
    /// </summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Venue;

    /// <inheritdoc cref="Documentation.Latitude" />
    public double Latitude { get; } = latitude;

    /// <inheritdoc cref="Documentation.Longitude" />
    public double Longitude { get; } = longitude;

    /// <summary>
    /// Title of the venue
    /// </summary>
    public string Title { get; } = title;

    /// <summary>
    /// Address of the venue
    /// </summary>
    public string Address { get; } = address;

    /// <summary>
    /// Optional. Foursquare identifier of the venue if known
    /// </summary>
    public string? FoursquareId { get; set; }

    /// <summary>
    /// Optional. Foursquare type of the venue. (For example, "arts_entertainment/default",
    /// "arts_entertainment/aquarium" or "food/icecream".)
    /// </summary>
    public string? FoursquareType { get; set; }

    /// <summary>
    /// Google Places identifier of the venue
    /// </summary>
    public string? GooglePlaceId { get; set; }

    /// <summary>
    /// Google Places type of the venue.
    /// <a href="https://developers.google.com/places/web-service/supported_types"/>
    /// </summary>
    public string? GooglePlaceType { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    public InputMessageContent? InputMessageContent { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailUrl" />
    public string? ThumbnailUrl { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailWidth" />
    public int? ThumbnailWidth { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailHeight" />
    public int? ThumbnailHeight { get; set; }
}
