using System.Text.Json;
using Telegram.Bot.Converters;
using Telegram.Bot.Types.Enums;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class EmojiConverterTests
{
    [Theory]
    [InlineData(Emoji.Dice, EmojiMapper.Dice)]
    [InlineData(Emoji.Darts, EmojiMapper.Darts)]
    [InlineData(Emoji.Basketball, EmojiMapper.Basketball)]
    [InlineData(Emoji.Football, EmojiMapper.Football)]
    [InlineData(Emoji.SlotMachine, EmojiMapper.SlotMachine)]
    [InlineData(Emoji.Bowling, EmojiMapper.Bowling)]
    public void Should_Convert_Emoji_To_String(Emoji emoji, string value)
    {
        Dice dice = new() { Emoji = emoji };
        string expectedResult = $$"""{"emoji":"{{value}}"}""";

        string result = JsonSerializer.Serialize(dice, JsonSerializerOptionsProvider.Options);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(Emoji.Dice, EmojiMapper.Dice)]
    [InlineData(Emoji.Darts, EmojiMapper.Darts)]
    [InlineData(Emoji.Basketball, EmojiMapper.Basketball)]
    [InlineData(Emoji.Football, EmojiMapper.Football)]
    [InlineData(Emoji.SlotMachine, EmojiMapper.SlotMachine)]
    [InlineData(Emoji.Bowling, EmojiMapper.Bowling)]
    public void Should_Convert_String_To_Emoji(Emoji emoji, string value)
    {
        Dice expectedResult = new() { Emoji = emoji };
        string jsonData = $$"""{"emoji":"{{value}}"}""";

        Dice? result = JsonSerializer.Deserialize<Dice>(jsonData, JsonSerializerOptionsProvider.Options);

        Assert.NotNull(result);
        Assert.Equal(expectedResult.Emoji, result.Emoji);
    }

    [Fact]
    public void Should_Return_Zero_For_Incorrect_Emoji()
    {
        string jsonData = $$"""{"emoji":"{{int.MaxValue}}"}""";

        Dice? result = JsonSerializer.Deserialize<Dice>(jsonData, JsonSerializerOptionsProvider.Options);

        Assert.NotNull(result);
        Assert.Equal((Emoji)0, result.Emoji);
    }

    [Fact]
    public void Should_Throw_NotSupportedException_For_Incorrect_Emoji()
    {
        Dice dice = new() { Emoji = (Emoji)int.MaxValue };

        // ToDo: add Emoji.Unknown ?
        //    protected override string GetStringValue(Emoji value) =>
        //        EnumToString.TryGetValue(value, out var stringValue)
        //            ? stringValue
        //            : "unknown";
        Assert.Throws<JsonException>(() => JsonSerializer.Serialize(dice, JsonSerializerOptionsProvider.Options));
    }

    class Dice
    {
        public Emoji Emoji { get; init; }
    }

    static class EmojiMapper
    {
        public const string Dice = "\\uD83C\\uDFB2";
        public const string Darts = "\\uD83C\\uDFAF";
        public const string Basketball = "\\uD83C\\uDFC0";
        public const string Football = "\\u26BD";
        public const string SlotMachine = "\\uD83C\\uDFB0";
        public const string Bowling = "\\uD83C\\uDFB3";
    }
}
