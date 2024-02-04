using System.Globalization;
using System.Linq;
using System.Net.Http;
using Telegram.Bot.Extensions;

namespace Telegram.Bot.Requests;

/// <summary>
/// Represents an API request with a file
/// </summary>
/// <typeparam name="TResponse">Type of result expected in result</typeparam>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public abstract class FileRequestBase<TResponse> : RequestBase<TResponse>
{
    /// <summary>
    /// Initializes an instance of request
    /// </summary>
    /// <param name="methodName">Bot API method</param>
    protected FileRequestBase(string methodName)
        : base(methodName)
    { }

    /// <summary>
    /// Initializes an instance of request
    /// </summary>
    /// <param name="methodName">Bot API method</param>
    /// <param name="method">HTTP method to use</param>
    protected FileRequestBase(string methodName, HttpMethod method)
        : base(methodName, method)
    { }

    /// <summary>
    /// Generate multipart form data content
    /// </summary>
    /// <param name="fileParameterName"></param>
    /// <param name="inputFile"></param>
    /// <returns></returns>
    protected MultipartFormDataContent ToMultipartFormDataContent(
        string fileParameterName,
        InputFileStream inputFile)
    {
        if (inputFile is null or { Content: null })
        {
            throw new ArgumentNullException(nameof(inputFile), $"{nameof(inputFile)} or it's content is null");
        }

        return GenerateMultipartFormDataContent(fileParameterName)
            .AddContentIfInputFile(media: inputFile, name: fileParameterName);
    }

    /// <summary>
    /// Generate multipart form data content
    /// </summary>
    /// <param name="exceptPropertyNames"></param>
    /// <returns></returns>
    protected MultipartFormDataContent GenerateMultipartFormDataContent(params string[] exceptPropertyNames)
    {
        var boundary = $"{Guid.NewGuid()}{DateTime.UtcNow.Ticks.ToString(CultureInfo.InvariantCulture)}";
        var multipartContent = new MultipartFormDataContent(boundary);

        var stringContents =
        #if NET7_0_OR_GREATER
            JsonSerializer.SerializeToElement(this).EnumerateObject()
        #else
            Newtonsoft.Json.Linq.JObject.FromObject(this).Properties()
        #endif
                .Where(prop => exceptPropertyNames.Contains(prop.Name, StringComparer.InvariantCulture) is false)
                .Select(prop => (name: prop.Name, content: new StringContent(prop.Value.ToString())));


        foreach (var strContent in stringContents)
        {
            multipartContent.Add(content: strContent.content, name: strContent.name);
        }

        return multipartContent;
    }
}
