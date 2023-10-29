namespace MyLibrary.Api.Requests.Books;

internal sealed record BorrowBookRequest
{
    /// <summary>
    /// The date on which the customer expects to return the book.
    /// </summary>
    /// <example>2023-12-25</example>
    public DateOnly ReturnDate { get; set; }
}