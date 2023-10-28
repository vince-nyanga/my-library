namespace MyLibrary.Query.Books.Dtos;

public sealed record ReservedBook : Book
{
    public string CustomerId { get; init; }
    public DateTime ExpiryDate { get; init; }
}