using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send information about a venue. On success, the sent <see cref="Message"/> is returned.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="latitude">Latitude of the venue</param>
/// <param name="longitude">Longitude of the venue</param>
/// <param name="title">Name of the venue</param>
/// <param name="address">Address of the venue</param>
public class SendVenueRequest(
    ChatId chatId,
    double latitude,
    double longitude,
    string title,
    string address)
        : RequestBase<Message>("sendVenue"),
          IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Latitude of the venue
    /// </summary>
    public double Latitude { get; } = latitude;

    /// <summary>
    /// Longitude of the venue
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
    /// Foursquare identifier of the venue
    /// </summary>
    public string? FoursquareId { get; set; }

    /// <summary>
    /// Foursquare type of the venue, if known. (For example, “arts_entertainment/default”,
    /// “arts_entertainment/aquarium” or “food/icecream”.)
    /// </summary>
    public string? FoursquareType { get; set; }

    /// <summary>
    /// Google Places identifier of the venue
    /// </summary>
    public string? GooglePlaceId { get; set; }

    /// <summary>
    /// Google Places type of the venue.
    /// (See <a href="https://developers.google.com/places/web-service/supported_types">supported types</a>.)
    /// </summary>
    public string? GooglePlaceType { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    public IReplyMarkup? ReplyMarkup { get; set; }
}
