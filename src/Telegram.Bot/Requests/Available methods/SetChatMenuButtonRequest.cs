﻿// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to change the bot’s menu button in a private chat, or the default menu button.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class SetChatMenuButtonRequest : RequestBase<bool>
{
    /// <summary>
    /// Optional. Unique identifier for the target private chat. If not specified, default bot’s menu button
    /// will be changed
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public long? ChatId { get; set; }

    /// <summary>
    /// Optional. An object for the new bot’s menu button. Defaults to <see cref="MenuButtonDefault"/>
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public MenuButton? MenuButton { get; set; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public SetChatMenuButtonRequest()
        : base("setChatMenuButton")
    { }
}
