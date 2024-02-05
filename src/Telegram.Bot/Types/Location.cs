namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a point on the map.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class Location
{
    /// <summary>
    /// Longitude as defined by sender
    /// </summary>
    [DataMember(IsRequired = true)]
    public double Longitude { get; set; }

    /// <summary>
    /// Latitude as defined by sender
    /// </summary>
    [DataMember(IsRequired = true)]
    public double Latitude { get; set; }

    /// <summary>
    /// Optional. The radius of uncertainty for the location, measured in meters; 0-1500
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public float? HorizontalAccuracy { get; set; }

    /// <summary>
    /// Optional. Time relative to the message sending date, during which the location can be updated, in seconds. For active live locations only.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? LivePeriod { get; set; }

    /// <summary>
    /// Optional. The direction in which user is moving, in degrees; 1-360. For active live locations only.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Heading { get; set; }

    /// <summary>
    /// Optional. Maximum distance for proximity alerts about approaching another chat member, in meters. For sent live locations only.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? ProximityAlertRadius { get; set; }
}
