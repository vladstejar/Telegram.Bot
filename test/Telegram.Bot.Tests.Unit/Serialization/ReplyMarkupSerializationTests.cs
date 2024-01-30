using System.Text.Json;
using Telegram.Bot.Converters;
using Telegram.Bot.Types.ReplyMarkups;
using Xunit;

namespace Telegram.Bot.Tests.Unit.Serialization;

public class ReplyMarkupSerializationTests
{
    [Theory(DisplayName = "Should serialize request poll keyboard button")]
    [InlineData(null)]
    [InlineData("regular")]
    [InlineData("quiz")]
    public void Should_Serialize_Request_Poll_Keyboard_Button(string type)
    {
        IReplyMarkup replyMarkup = new ReplyKeyboardMarkup(
            KeyboardButton.WithRequestPoll("Create a poll", type)
        );

        string serializedReplyMarkup = JsonSerializer.Serialize(replyMarkup, JsonSerializerOptionsProvider.Options);

        string formattedType = string.IsNullOrEmpty(type)
            ? "{}"
            : $@"{{""type"":""{type}""}}";

        string expectedString = $@"""request_poll"":{formattedType}";

        Assert.Contains(expectedString, serializedReplyMarkup);
    }
}
