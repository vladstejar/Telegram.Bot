using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Converters;

/// <summary>
///
/// </summary>
public static class JsonSerializerOptionsProvider
{
    /// <summary>
    ///
    /// </summary>
    public static JsonSerializerOptions Options => new()
    {
        // Encoder = new TelegramEmojiesEscaper(),
        Converters =
        {
            new MenuButtonConverter(),
            new ChatMemberConverter(),
            new UnixDateTimeConverter(),
            new NullableUnixDateTimeConverter(),
            new BanTimeUnixDateTimeConverter(),
            new ColorConverter(),
            new InputFileConverter(),
            new InputMediaTypeConverter(),
            new ChatIdConverter(),
        },
        PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };
}
