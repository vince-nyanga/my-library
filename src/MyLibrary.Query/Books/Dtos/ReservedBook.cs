namespace MyLibrary.Query.Books.Dtos;

public sealed record ReservedBook : Book
{
    public string CustomerId { get; init; }
    public DateTimeOffset ExpiryDate { get; init; }
}