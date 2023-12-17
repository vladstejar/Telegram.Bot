namespace Telegram.Bot.Converters;

[JsonSourceGenerationOptions(
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault)]
[JsonSerializable(typeof(ChatId))]
internal partial class TelegramJsonContext : JsonSerializerContext
{
}
