// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents the content of a contact message to be sent as the result of an <see cref="InlineQuery">inline query</see>.
/// </summary>
/// <remarks>
/// Initializes a new input contact message content
/// </remarks>
/// <param name="phoneNumber">The phone number of the contact</param>
/// <param name="firstName">The first name of the contact</param>
public class InputContactMessageContent(string phoneNumber, string firstName) : InputMessageContent
{
    /// <summary>
    /// Contact's phone number
    /// </summary>
    public string PhoneNumber { get; } = phoneNumber;

    /// <summary>
    /// Contact's first name
    /// </summary>
    public string FirstName { get; } = firstName;

    /// <summary>
    /// Optional. Contact's last name
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Optional. Additional data about the contact in the form of a vCard, 0-2048 bytes
    /// </summary>
    public string? Vcard { get; set; }
}
