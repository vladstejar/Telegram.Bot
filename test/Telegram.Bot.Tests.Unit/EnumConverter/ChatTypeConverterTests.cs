using System.Runtime.Serialization;
using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class ChatTypeConverterTests
{
    [Theory]
    [InlineData(ChatType.Private, "private")]
    [InlineData(ChatType.Group, "group")]
    [InlineData(ChatType.Channel, "channel")]
    [InlineData(ChatType.Supergroup, "supergroup")]
    [InlineData(ChatType.Sender, "sender")]
    public void Should_Convert_ChatType_To_String(ChatType chatType, string value)
    {
        InlineQuery inlineQuery = new() { Type = chatType };
        string expectedResult = @$"{{""type"":""{value}""}}";

        string result = Serializer.Serialize(inlineQuery);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(ChatType.Private, "private")]
    [InlineData(ChatType.Group, "group")]
    [InlineData(ChatType.Channel, "channel")]
    [InlineData(ChatType.Supergroup, "supergroup")]
    [InlineData(ChatType.Sender, "sender")]
    public void Should_Convert_String_To_ChatType(ChatType chatType, string value)
    {
        InlineQuery expectedResult = new() { Type = chatType };
        string jsonData = @$"{{""type"":""{value}""}}";

        InlineQuery? result = Serializer.Deserialize<InlineQuery>(jsonData);

        Assert.NotNull(result);
        Assert.Equal(expectedResult.Type, result.Type);
    }

    [Fact]
    public void Should_Return_Zero_For_Incorrect_ChatType()
    {
        string jsonData = @$"{{""type"":""{int.MaxValue}""}}";

        InlineQuery? result = Serializer.Deserialize<InlineQuery>(jsonData);

        Assert.NotNull(result);
        Assert.Equal((ChatType)0, result.Type);
    }

    [Fact]
    public void Should_Throw_NotSupportedException_For_Incorrect_ChatType()
    {
        InlineQuery inlineQuery = new() { Type = (ChatType)int.MaxValue };

        // ToDo: add ChatType.Unknown ?
        //    protected override string GetStringValue(ChatType value) =>
        //        EnumToString.TryGetValue(value, out var stringValue)
        //            ? stringValue
        //            : "unknown";
#if NET8_0_OR_GREATER
        Assert.Throws<JsonException>(() => Serializer.Serialize(inlineQuery));
#else
        Assert.Throws<NotSupportedException>(() => Serializer.Serialize(inlineQuery));
#endif
    }

#if !NET8_0_OR_GREATER
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
    [DataContract]
    class InlineQuery
    {
        [DataMember(IsRequired = true)]
        public ChatType Type { get; init; }
    }
}
