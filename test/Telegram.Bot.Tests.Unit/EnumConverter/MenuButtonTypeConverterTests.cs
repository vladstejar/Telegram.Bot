using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using Telegram.Bot.Types.Enums;
using Xunit;
using JsonException = System.Text.Json.JsonException;

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class MenuButtonTypeConverterTests
{
    [Theory]
    [InlineData(MenuButtonType.Default, "default")]
    [InlineData(MenuButtonType.Commands, "commands")]
    [InlineData(MenuButtonType.WebApp, "web_app")]
    public void Should_Convert_MenuButtonType_To_String(MenuButtonType menuButtonType, string value)
    {
        MenuButton menuButton = new() { Type = menuButtonType };
        string expectedResult = @$"{{""type"":""{value}""}}";

        string result = Serializer.Serialize(menuButton);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(MenuButtonType.Default, "default")]
    [InlineData(MenuButtonType.Commands, "commands")]
    [InlineData(MenuButtonType.WebApp, "web_app")]
    public void Should_Convert_String_To_MenuButtonType(MenuButtonType menuButtonType, string value)
    {
        MenuButton expectedResult = new() { Type = menuButtonType };
        string jsonData = @$"{{""type"":""{value}""}}";

        MenuButton? result = Serializer.Deserialize<MenuButton>(jsonData);

        Assert.NotNull(result);
        Assert.Equal(expectedResult.Type, result.Type);
    }

    [Fact]
    public void Should_Return_Zero_For_Incorrect_MenuButtonType()
    {
        string jsonData = @$"{{""type"":""{int.MaxValue}""}}";

        MenuButton? result = Serializer.Deserialize<MenuButton>(jsonData);

        Assert.NotNull(result);
        Assert.Equal((MenuButtonType)0, result.Type);
    }

    [Fact]
    public void Should_Throw_NotSupportedException_For_Incorrect_MenuButtonType()
    {
        MenuButton menuButton = new() { Type = (MenuButtonType)int.MaxValue };

        // ToDo: add InputMediaType.Unknown ?
        //    protected override string GetStringValue(InputMediaType value) =>
        //        EnumToString.TryGetValue(value, out var stringValue)
        //            ? stringValue
        //            : "unknown";
#if NET8_0_OR_GREATER
        Assert.Throws<JsonException>(() => Serializer.Serialize(menuButton));
#else
        Assert.Throws<NotSupportedException>(() => Serializer.Serialize(menuButton));
#endif
    }

    #if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    #endif
    class MenuButton
    {
        #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
        public MenuButtonType Type { get; init; }
    }
}
