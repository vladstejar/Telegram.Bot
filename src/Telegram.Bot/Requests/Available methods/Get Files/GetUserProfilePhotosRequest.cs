using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get a list of profile pictures for a user. Returns a
/// <see cref="UserProfilePhotos"/> object.
/// </summary>
/// <param name="userId">Unique identifier of the target user</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetUserProfilePhotosRequest(long userId)
    : RequestBase<UserProfilePhotos>("getUserProfilePhotos"),
      IUserTargetable
{
    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public long UserId { get; } = userId;

    /// <summary>
    /// Sequential number of the first photo to be returned. By default, all photos are returned
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? Offset { get; set; }

    /// <summary>
    /// Limits the number of photos to be retrieved. Values between 1-100 are accepted. Defaults to 100
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? Limit { get; set; }
}
