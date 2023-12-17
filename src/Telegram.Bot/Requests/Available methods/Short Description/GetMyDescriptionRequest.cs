// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get the current bot <see cref="BotShortDescription">short description</see>
/// for the given <see cref="LanguageCode">user language</see>.
/// Returns <see cref="BotShortDescription"/> on success.
/// </summary>
public class GetMyShortDescriptionRequest() : RequestBase<BotShortDescription>("getMyShortDescription")
{
    /// <summary>
    /// A two-letter ISO 639-1 language code or an empty string
    /// </summary>
    public string? LanguageCode { get; set; }
}
