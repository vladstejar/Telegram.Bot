using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit live location messages. A location can be edited until its
/// <see cref="Types.Location.LivePeriod"/> expires or editing is explicitly disabled by a call to
/// <see cref="StopMessageLiveLocationRequest"/>. On success the edited <see cref="Message"/> is returned.
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="messageId">Identifier of the message to edit</param>
/// <param name="latitude">Latitude of new location</param>
/// <param name="longitude">Longitude of new location</param>
public class EditMessageLiveLocationRequest(ChatId chatId, int messageId, double latitude, double longitude)
    : RequestBase<Message>("editMessageLiveLocation"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Identifier of the message to edit
    /// </summary>
    public int MessageId { get; } = messageId;

    /// <summary>
    /// Latitude of new location
    /// </summary>
    public double Latitude { get; } = latitude;

    /// <summary>
    /// Longitude of new location
    /// </summary>
    public double Longitude { get; } = longitude;

    /// <summary>
    /// The radius of uncertainty for the location, measured in meters; 0-1500
    /// </summary>
    public float? HorizontalAccuracy { get; set; }

    /// <summary>
    /// Direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
    /// </summary>
    public int? Heading { get; set; }

    /// <summary>
    /// Maximum distance for proximity alerts about approaching another chat member, in meters.
    /// Must be between 1 and 100000 if specified.
    /// </summary>
    public int? ProximityAlertRadius { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.InlineReplyMarkup"/>
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}
