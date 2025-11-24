namespace ThirdPartyLibrary;

public sealed record Report(
    string Title,
    DateTime Date,
    IReadOnlyCollection<string> Rows
);