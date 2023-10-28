using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

internal sealed class BorrowedBookCopy : Entity<BorrowedBookId>
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
        IsReturned = false;
    }
    
    public CustomerId CustomerId { get; init; }
    public BookId BookId { get; init; }
    public DateOnly DueDate { get; init; }
    public bool IsReturned { get; private set; }
    public DateOnly? DateReturned { get; private set; }

    public void Return()
    {
        if (IsReturned)
        {
            throw new BookCopyAlreadyReturnedException(Id, BookId);
        }
        
        IsReturned = true;
        DateReturned = DateOnly.FromDateTime(DateTime.Today);
    }
}