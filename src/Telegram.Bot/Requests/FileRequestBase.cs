using System.Globalization;
using System.Linq;
using System.Net.Http;
using Telegram.Bot.Extensions;

namespace Telegram.Bot.Requests;

/// <summary>
/// Represents an API request with a file
/// </summary>
/// <typeparam name="TResponse">Type of result expected in result</typeparam>
/// <param name="methodName">Bot API method</param>
/// <param name="method">HTTP method to use</param>
public abstract class FileRequestBase<TResponse>(string methodName, HttpMethod? method = default)
    : RequestBase<TResponse>(methodName, method)
{
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
            throw new ArgumentNullException(nameof(inputFile), $"{nameof(inputFile)} or it's content is null");

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

        var stringContents = JsonSerializer.SerializeToElement(this)
            .EnumerateObject()
            .Where(prop => exceptPropertyNames.Contains(prop.Name, StringComparer.InvariantCulture) is false)
            .Select(prop => (name: prop.Name, content: new StringContent(prop.Value.ToString())));

        foreach (var (name, content) in stringContents)
            multipartContent.Add(content: content, name: name);

        return multipartContent;
    }
}
