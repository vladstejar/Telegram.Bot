using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send point on the map. On success, the sent <see cref="Message"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SendLocationRequest : RequestBase<Message>, IChatTargetable
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
    /// Latitude of the location
    /// </summary>
    [DataMember(IsRequired = true)]
    public double Latitude { get; }

    /// <summary>
    /// Longitude of the location
    /// </summary>
    [DataMember(IsRequired = true)]
    public double Longitude { get; }

    /// <summary>
    /// Period in seconds for which the location will be updated, should be between 60 and 86400
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? LivePeriod { get; set; }

    /// <summary>
    /// For live locations, a direction in which the user is moving, in degrees.
    /// Must be between 1 and 360 if specified.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Heading { get; set; }

    /// <summary>
    /// For live locations, a maximum distance for proximity alerts about approaching another
    /// chat member, in meters. Must be between 1 and 100000 if specified.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? ProximityAlertRadius { get; set; }

    /// <summary>
    /// Sends the message silently. Users will receive a notification with no sound.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? ProtectContent { get; set; }

    /// <summary>
    /// If the message is a reply, ID of the original message
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? ReplyToMessageId { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the message should be sent even if the specified replied-to message is not found
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    [DataMember(EmitDefaultValue = false)]
    public IReplyMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with chatId, latitude and longitude
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="latitude">Latitude of the location</param>
    /// <param name="longitude">Longitude of the location</param>
    public SendLocationRequest(ChatId chatId, double latitude, double longitude)
        : base("sendLocation")
    {
        ChatId = chatId;
        Latitude = latitude;
        Longitude = longitude;
    }
}
