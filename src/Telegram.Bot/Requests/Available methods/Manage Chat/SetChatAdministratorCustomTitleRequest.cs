using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set a custom title for an administrator in a supergroup promoted by the bot.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class SetChatAdministratorCustomTitleRequest : RequestBase<bool>, IChatTargetable, IUserTargetable
{
    /// <inheritdoc />
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public ChatId ChatId { get; }

    /// <inheritdoc />
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public long UserId { get; }

    /// <summary>
    /// New custom title for the administrator; 0-16 characters, emoji are not allowed
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string CustomTitle { get; }

    /// <summary>
    /// Initializes a new request with chatId, userId and customTitle
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="userId">Unique identifier of the target user</param>
    /// <param name="customTitle">
    /// New custom title for the administrator; 0-16 characters, emoji are not allowed
    /// </param>
    public SetChatAdministratorCustomTitleRequest(ChatId chatId, long userId, string customTitle)
        : base("setChatAdministratorCustomTitle")
    {
        ChatId = chatId;
        UserId = userId;
        CustomTitle = customTitle;
    }
}
