using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send information about a venue. On success, the sent <see cref="Message"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SendVenueRequest : RequestBase<Message>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Latitude of the venue
    /// </summary>
    [DataMember(IsRequired = true)]
    public double Latitude { get; }

    /// <summary>
    /// Longitude of the venue
    /// </summary>
    [DataMember(IsRequired = true)]
    public double Longitude { get; }

    /// <summary>
    /// Name of the venue
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Title { get; }

    /// <summary>
    /// Address of the venue
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Address { get; }

    /// <summary>
    /// Foursquare identifier of the venue
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? FoursquareId { get; set; }

    /// <summary>
    /// Foursquare type of the venue, if known. (For example, “arts_entertainment/default”,
    /// “arts_entertainment/aquarium” or “food/icecream”.)
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
    /// (See <a href="https://developers.google.com/places/web-service/supported_types">supported types</a>.)
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? GooglePlaceType { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    [DataMember(EmitDefaultValue = false)]
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    [DataMember(EmitDefaultValue = false)]
    public IReplyMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with chatId, location, venue title and address
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="latitude">Latitude of the venue</param>
    /// <param name="longitude">Longitude of the venue</param>
    /// <param name="title">Name of the venue</param>
    /// <param name="address">Address of the venue</param>
    public SendVenueRequest(
        ChatId chatId,
        double latitude,
        double longitude,
        string title,
        string address) : base("sendVenue")
    {
        ChatId = chatId;
        Latitude = latitude;
        Longitude = longitude;
        Title = title;
        Address = address;
    }
}
