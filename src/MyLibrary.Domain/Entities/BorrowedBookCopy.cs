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
        Returned = false;
    }
    
    public CustomerId CustomerId { get; private set; }
    public BookId BookId { get; private set; }
    public DateOnly DueDate { get; private set; }
    
    public bool Returned { get; private set; }
    
    public DateOnly? DateReturned { get; private set; }

    public void Return()
    {
        Returned = true;
        DateReturned = DateOnly.FromDateTime(DateTime.Today);
    }
}