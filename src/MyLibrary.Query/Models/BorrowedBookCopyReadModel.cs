namespace MyLibrary.Query.Models;

internal sealed class BorrowedBookCopyReadModel
{
    public Guid Id { get; set; }
    public string CustomerId { get; init; }
    public Guid BookId { get; init; }
    public DateOnly DueDate { get; init; }
    public bool IsReturned { get; private set; }
    public DateOnly? DateReturned { get; private set; }
}