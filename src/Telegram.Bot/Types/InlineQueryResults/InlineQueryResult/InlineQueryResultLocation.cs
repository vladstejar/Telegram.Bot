

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a location on a map. By default, the location will be sent by the user. Alternatively,
/// you can use <see cref="InlineQueryResultLocation.InputMessageContent"/> to send a message with
/// the specified content instead of the location.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InlineQueryResultLocation : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be location
    /// </summary>
    [DataMember(IsRequired = true)]
    public override InlineQueryResultType Type => InlineQueryResultType.Location;

    /// <inheritdoc cref="Documentation.Latitude" />
    [DataMember(IsRequired = true)]
    public double Latitude { get; }

    /// <inheritdoc cref="Documentation.Longitude" />
    [DataMember(IsRequired = true)]
    public double Longitude { get; }

    /// <summary>
    /// Location title
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Title { get; }

    /// <summary>
    /// Optional. The radius of uncertainty for the location, measured in meters; 0-1500
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public float? HorizontalAccuracy { get; set; }

    /// <summary>
    /// Optional. Period in seconds for which the location can be updated, should be between 60 and 86400.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? LivePeriod { get; set; }

    /// <summary>
    /// Optional. For live locations, a direction in which the user is moving, in degrees.
    /// Must be between 1 and 360 if specified.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Heading { get; set; }

    /// <summary>
    /// Optional. For live locations, a maximum distance for proximity alerts about approaching
    /// another chat member, in meters. Must be between 1 and 100000 if specified.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? ProximityAlertRadius { get; set; }

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
    public InlineQueryResultLocation(string id, double latitude, double longitude, string title)
        : base(id)
    {
        Latitude = latitude;
        Longitude = longitude;
        Title = title;
    }
}
