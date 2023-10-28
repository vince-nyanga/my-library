using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

/// <summary>
/// Naming things is very hard...🤣
/// </summary>
internal class WatchedBook : Entity<WatchedBookId>
{
    public WatchedBook(WatchedBookId id, CustomerId customerId, BookId bookId, string bookTitle)
    {
        Id = id;
        CustomerId = customerId;
        BookId = bookId;
        BookTitle = bookTitle;
    }
    
    public CustomerId CustomerId { get; init; }
    public BookId BookId { get; init; }
    public string BookTitle { get; init; }

    public virtual Customer Customer { get; set; }
}