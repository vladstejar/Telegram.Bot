using System.Text.Encodings.Web;
using System.Text.Json;
using Telegram.Bot.Converters;
using Xunit;

namespace Telegram.Bot.Tests.Unit.Serialization;

public class EmojiSerializationTests
{
    [Fact]
    public void Should_Serialize_Emojies_In_Text()
    {
        string text = "🎲🎯🏀⚽🎰🎳";

        string serializedEmojies = JsonSerializer.Serialize(text, JsonSerializerOptionsProvider.Options);
        Assert.Equal($"\"{JavaScriptEncoder.Default.Encode("🎲🎯🏀⚽🎰🎳")}\"", serializedEmojies);
    }
}
