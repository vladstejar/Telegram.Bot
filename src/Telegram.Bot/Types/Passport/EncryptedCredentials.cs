// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.Passport;

/// <summary>
/// Contains data required for decrypting and authenticating <see cref="EncryptedPassportElement"/>.
/// See the <a href="https://core.telegram.org/passport#receiving-information">Telegram Passport
/// Documentation</a> for a complete description of the data decryption and authentication processes.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class EncryptedCredentials
{
    /// <summary>
    /// Base64-encoded encrypted JSON-serialized data with unique user's payload, data hashes and secrets
    /// required for <see cref="EncryptedPassportElement"/> decryption and authentication.
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Data { get; set; } = default!;

    /// <summary>
    /// Base64-encoded data hash for data authentication.
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Hash { get; set; } = default!;

    /// <summary>
    /// Base64-encoded secret, encrypted with the bot’s public RSA key, required for data decryption.
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Secret { get; set; } = default!;
}
