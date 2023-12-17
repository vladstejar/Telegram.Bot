using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents the content of a <see cref="Venue"/> message to be sent as the result of an
/// <see cref="InlineQuery">inline query</see>.
/// </summary>
/// <remarks>
/// Initializes a new inline query result
/// </remarks>
/// <param name="title">The name of the venue</param>
/// <param name="address">The address of the venue</param>
/// <param name="latitude">The latitude of the venue</param>
/// <param name="longitude">The longitude of the venue</param>
[PublicAPI]
public class InputVenueMessageContent(
    string title,
    string address,
    double latitude,
    double longitude)
        : InputMessageContent
{
    /// <summary>
    /// Latitude of the venue in degrees
    /// </summary>
    public double Latitude { get; } = latitude;

    /// <summary>
    /// Longitude of the venue in degrees
    /// </summary>
    public double Longitude { get; } = longitude;

    /// <summary>
    /// Name of the venue
    /// </summary>
    public string Title { get; } = title;

    /// <summary>
    /// Address of the venue
    /// </summary>
    public string Address { get; } = address;

    /// <summary>
    /// Optional. Foursquare identifier of the venue, if known
    /// </summary>
    public string? FoursquareId { get; set; }

    /// <summary>
    /// Optional. Foursquare type of the venue. (For example, “arts_entertainment/default”,
    /// “arts_entertainment/aquarium” or “food/icecream”.)
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
}
