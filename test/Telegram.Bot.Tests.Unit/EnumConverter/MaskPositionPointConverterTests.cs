using System.Runtime.Serialization;
using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class MaskPositionPointConverterTests
{
    [Theory]
    [InlineData(MaskPositionPoint.Forehead, "forehead")]
    [InlineData(MaskPositionPoint.Eyes, "eyes")]
    [InlineData(MaskPositionPoint.Mouth, "mouth")]
    [InlineData(MaskPositionPoint.Chin, "chin")]
    public void Should_Convert_MaskPositionPoint_To_String(MaskPositionPoint maskPositionPoint, string value)
    {
        MaskPosition maskPosition = new() { Point = maskPositionPoint };
        string expectedResult = @$"{{""point"":""{value}""}}";

        string result = Serializer.Serialize(maskPosition);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(MaskPositionPoint.Forehead, "forehead")]
    [InlineData(MaskPositionPoint.Eyes, "eyes")]
    [InlineData(MaskPositionPoint.Mouth, "mouth")]
    [InlineData(MaskPositionPoint.Chin, "chin")]
    public void Should_Convert_String_To_MaskPositionPoint(MaskPositionPoint maskPositionPoint, string value)
    {
        MaskPosition expectedResult = new() { Point = maskPositionPoint };
        string jsonData = @$"{{""point"":""{value}""}}";

        MaskPosition? result = Serializer.Deserialize<MaskPosition>(jsonData);

        Assert.NotNull(result);
        Assert.Equal(expectedResult.Point, result.Point);
    }

    [Fact]
    public void Should_Return_Zero_For_Incorrect_MaskPositionPoint()
    {
        string jsonData = @$"{{""point"":""{int.MaxValue}""}}";

        MaskPosition? result = Serializer.Deserialize<MaskPosition>(jsonData);

        Assert.NotNull(result);
        Assert.Equal((MaskPositionPoint)0, result.Point);
    }

    [Fact]
    public void Should_Throw_NotSupportedException_For_Incorrect_MaskPositionPoint()
    {
        MaskPosition maskPosition = new() { Point = (MaskPositionPoint)int.MaxValue };

        // ToDo: add MaskPositionPoint.Unknown ?
        //    protected override string GetStringValue(MaskPositionPoint value) =>
        //        EnumToString.TryGetValue(value, out var stringValue)
        //            ? stringValue
        //            : "unknown";
#if NET8_0_OR_GREATER
        Assert.Throws<JsonException>(() => Serializer.Serialize(maskPosition));
#else
        Assert.Throws<NotSupportedException>(() => Serializer.Serialize(maskPosition));
#endif
    }

#if !NET8_0_OR_GREATER
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
    [DataContract]
    class MaskPosition
    {
        [DataMember(IsRequired = true)]
        public MaskPositionPoint Point { get; init; }
    }
}
