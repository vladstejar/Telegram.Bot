namespace EnumSerializer.Generator;

internal sealed class EnumInfo(
    string name,
    string ns,
    IReadOnlyList<KeyValuePair<string, string>> members)
{
    public string Name { get; } = name;
    public string Namespace { get; } = ns;

    /// <summary>
    /// Key is the enum name.
    /// </summary>
    public  IReadOnlyList<KeyValuePair<string, string>> Members { get; } = members;
}
