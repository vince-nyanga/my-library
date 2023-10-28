namespace MyLibrary.Query.Models;

internal class BorrowedBookCopyReadModel
{
    public Guid Id { get; set; }
    public string CustomerId { get; init; }
    public Guid BookId { get; init; }
    public DateOnly DueDate { get; init; }
    public bool IsReturned { get; init; }
    public DateOnly? DateReturned { get; init; }
    
    public virtual BookReadModel Book { get; set; }
}