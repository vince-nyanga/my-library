namespace MyLibrary.Query.Customers.Dtos;

public sealed record CustomerSummary
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string EmailAddress { get; init; }
    public ushort TotalUnreadNotifications { get; init; }
    public ushort TotalReservedBooks { get; init; }
    public ushort TotalBorrowedBooks { get; init; }
}