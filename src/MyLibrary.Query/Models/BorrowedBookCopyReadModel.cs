namespace MyLibrary.Query.Models;

public sealed class BorrowedBookCopyReadModel
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; init; }
    public Guid BookId { get; init; }
    public DateOnly DueDate { get; init; }
    public bool Returned { get; private set; }
    public DateOnly? DateReturned { get; private set; }
}