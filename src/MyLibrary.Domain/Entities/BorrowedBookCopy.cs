using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class BorrowedBookCopy : Entity<BorrowedBookId>
{
    
    private BorrowedBookCopy()
    {
    }

    internal BorrowedBookCopy(BorrowedBookId id, CustomerId customerId, BookId bookId, DateOnly dueDate)
    {
        Id = id;
        CustomerId = customerId;
        BookId = bookId;
        DueDate = dueDate;
    }
    
    public CustomerId CustomerId { get; private set; }
    public BookId BookId;
    public DateOnly DueDate;
}