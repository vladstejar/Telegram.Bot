using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get a list of profile pictures for a user. Returns a
/// <see cref="UserProfilePhotos"/> object.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class GetUserProfilePhotosRequest : RequestBase<UserProfilePhotos>, IUserTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public long UserId { get; }

    /// <summary>
    /// Sequential number of the first photo to be returned. By default, all photos are returned
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Offset { get; set; }

    /// <summary>
    /// Limits the number of photos to be retrieved. Values between 1-100 are accepted. Defaults to 100
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Limit { get; set; }

    /// <summary>
    /// Initializes a new request with userId
    /// </summary>
    /// <param name="userId">Unique identifier of the target user</param>
    public GetUserProfilePhotosRequest(long userId)
        : base("getUserProfilePhotos")
    {
        UserId = userId;
    }
}
