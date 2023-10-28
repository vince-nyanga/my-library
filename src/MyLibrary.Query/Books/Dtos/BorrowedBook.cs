namespace MyLibrary.Query.Books.Dtos;

public sealed record BorrowedBook : Book
{
    public string CustomerId { get; init; }
    public DateOnly DueDate { get; init; }
}