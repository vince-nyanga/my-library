namespace MyLibrary.Api.Responses.Profile;

internal sealed record ProfileResponse
{
    public string FullName { get; init; }
    public string EmailAddress { get; init; }
    public ushort TotalUnreadNotifications { get; init; }
}