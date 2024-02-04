#if !NET7_0_OR_GREATER
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
#endif
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.Enums;
using Xunit;
#if NET7_0_OR_GREATER
using JsonException = System.Text.Json.JsonException;
#endif

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class EmojiConverterTests
{
    [Theory]
    [InlineData(Emoji.Dice, "🎲")]
    [InlineData(Emoji.Darts, "🎯")]
    [InlineData(Emoji.Basketball, "🏀")]
    [InlineData(Emoji.Football, "⚽")]
    [InlineData(Emoji.SlotMachine, "🎰")]
    [InlineData(Emoji.Bowling, "🎳")]
    public void Should_Convert_Emoji_To_String(Emoji emoji, string value)
    {
        Dice dice = new() { Emoji = emoji };

        string escapedValue =
#if NET7_0_OR_GREATER
            EscapeUnicode(value);
#else
            value;
#endif

        string expectedResult = @$"{{""emoji"":""{escapedValue}""}}";

        string result = Serializer.Serialize(dice);



        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(Emoji.Dice, "🎲")]
    [InlineData(Emoji.Darts, "🎯")]
    [InlineData(Emoji.Basketball, "🏀")]
    [InlineData(Emoji.Football, "⚽")]
    [InlineData(Emoji.SlotMachine, "🎰")]
    [InlineData(Emoji.Bowling, "🎳")]
    public void Should_Convert_String_To_Emoji(Emoji emoji, string value)
    {
        Dice expectedResult = new() { Emoji = emoji };

        string escapedValue =
#if NET7_0_OR_GREATER
            EscapeUnicode(value);
#else
            value;
#endif

        string jsonData = @$"{{""emoji"":""{escapedValue}""}}";

        Dice? result = Serializer.Deserialize<Dice>(jsonData);

        Assert.NotNull(result);
        Assert.Equal(expectedResult.Emoji, result.Emoji);
    }

    [Fact]
    public void Should_Return_Zero_For_Incorrect_Emoji()
    {
        string jsonData = @$"{{""emoji"":""{int.MaxValue}""}}";

        Dice? result = Serializer.Deserialize<Dice>(jsonData);

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
#if NET7_0_OR_GREATER
        Assert.Throws<JsonException>(() => Serializer.Serialize(dice));
#else
        Assert.Throws<NotSupportedException>(() => Serializer.Serialize(dice));
#endif
    }

    static string EscapeUnicode(string value)
    {
        byte[] bytes = Encoding.BigEndianUnicode.GetBytes(value);
        List<string> escapedUnicode = new();
        for (int i = 0; i < bytes.Length; i += 2)
        {
            byte[] c = bytes[i..(i + 2)];
            string hexFormatted = BitConverter.ToString(c).Replace("-", "").ToUpperInvariant();
            escapedUnicode.Add($@"\u{hexFormatted}");
        }

        return string.Join("", escapedUnicode);
    }

#if !NET7_0_OR_GREATER
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
    class Dice
    {
#if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
#endif
        public Emoji Emoji { get; init; }
    }
}
