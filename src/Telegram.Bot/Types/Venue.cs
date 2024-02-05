namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a venue.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class Venue
{
    /// <summary>
    /// Venue location
    /// </summary>
    [DataMember(IsRequired = true)]
    public Location Location { get; set; } = default!;

    /// <summary>
    /// Name of the venue
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Title { get; set; } = default!;

    /// <summary>
    /// Address of the venue
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Address { get; set; } = default!;

    /// <summary>
    /// Optional. Foursquare identifier of the venue
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
    /// Optional. Google Places identifier of the venue
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? GooglePlaceId { get; set; }

    /// <summary>
    /// Optional. Google Places type of the venue. (See
    /// <a href="https://developers.google.com/places/web-service/supported_types">supported types</a>.)
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? GooglePlaceType { get; set; }
}
