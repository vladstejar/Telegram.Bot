using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to change the list of the bot’s commands. See
/// <a href="https://core.telegram.org/bots#commands"/> for more details about bot commands.
/// Returns <see langword="true"/> on success
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class SetMyCommandsRequest : RequestBase<bool>
{
    /// <summary>
    /// A list of bot commands to be set as the list of the bot’s commands.
    /// At most 100 commands can be specified.
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public IEnumerable<BotCommand> Commands { get; }

    /// <summary>
    /// An object, describing scope of users for which the commands are relevant.
    /// Defaults to <see cref="BotCommandScopeDefault"/>.
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public BotCommandScope? Scope { get; set; }

    /// <summary>
    /// A two-letter ISO 639-1 language code. If empty, commands will be applied to all users
    /// from the given <see cref="Scope"/>, for whose language there are no dedicated commands
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? LanguageCode { get; set; }

    /// <summary>
    /// Initializes a new request with commands
    /// </summary>
    /// <param name="commands">A list of bot commands to be set</param>
    public SetMyCommandsRequest(IEnumerable<BotCommand> commands)
        : base("setMyCommands")
    {
        Commands = commands;
    }
}
