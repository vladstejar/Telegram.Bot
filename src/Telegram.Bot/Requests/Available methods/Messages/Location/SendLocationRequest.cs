using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send point on the map. On success, the sent <see cref="Message"/> is returned.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="latitude">Latitude of the location</param>
/// <param name="longitude">Longitude of the location</param>
public class SendLocationRequest(ChatId chatId, double latitude, double longitude)
    : RequestBase<Message>("sendLocation"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Latitude of the location
    /// </summary>
    public double Latitude { get; } = latitude;

    /// <summary>
    /// Longitude of the location
    /// </summary>
    public double Longitude { get; } = longitude;

    /// <summary>
    /// Period in seconds for which the location will be updated, should be between 60 and 86400
    /// </summary>
    public int? LivePeriod { get; set; }

    /// <summary>
    /// For live locations, a direction in which the user is moving, in degrees.
    /// Must be between 1 and 360 if specified.
    /// </summary>
    public int? Heading { get; set; }

    /// <summary>
    /// For live locations, a maximum distance for proximity alerts about approaching another
    /// chat member, in meters. Must be between 1 and 100000 if specified.
    /// </summary>
    public int? ProximityAlertRadius { get; set; }

    /// <summary>
    /// Sends the message silently. Users will receive a notification with no sound.
    /// </summary>
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    public bool? ProtectContent { get; set; }

    /// <summary>
    /// If the message is a reply, ID of the original message
    /// </summary>
    public int? ReplyToMessageId { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the message should be sent even if the specified replied-to message is not found
    /// </summary>
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    public IReplyMarkup? ReplyMarkup { get; set; }
}
