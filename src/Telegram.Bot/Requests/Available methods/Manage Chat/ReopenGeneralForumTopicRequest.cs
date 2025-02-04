﻿namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to reopen a closed 'General' topic in a forum supergroup chat. The bot must be an administrator in the chat for this to work and must have the <em>CanManageTopics</em> administrator rights. The topic will be automatically unhidden if it was hidden.<para>Returns: </para>
/// </summary>
public partial class ReopenGeneralForumTopicRequest : RequestBase<bool>, IChatTargetable
{
    /// <summary>
    /// Unique identifier for the target chat or username of the target supergroup (in the format <c>@supergroupusername</c>)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; set; }

    /// <summary>
    /// Initializes an instance of <see cref="ReopenGeneralForumTopicRequest"/>
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup (in the format <c>@supergroupusername</c>)</param>
    [Obsolete("Use parameterless constructor with required properties")]
    [SetsRequiredMembers]
    public ReopenGeneralForumTopicRequest(ChatId chatId)
        : this() => ChatId = chatId;

    /// <summary>
    /// Instantiates a new <see cref="ReopenGeneralForumTopicRequest"/>
    /// </summary>
    public ReopenGeneralForumTopicRequest()
        : base("reopenGeneralForumTopic")
    { }
}
