namespace Telegram.Bot.Types;

/// <summary>
/// Contains information about a <a href="https://core.telegram.org/bots/webapps ">Web App</a>
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class WebAppInfo
{
    /// <summary>
    /// An HTTPS URL of a Web App to be opened with additional data as specified in
    /// <a href="https://core.telegram.org/bots/webapps#initializing-web-apps">Initializing Web Apps</a>
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Url { get; set; } = default!;
}
