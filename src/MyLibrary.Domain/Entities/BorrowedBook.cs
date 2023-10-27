using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class BorrowedBook : Entity<BorrowedBookId>
{
    private CustomerId _customerId;
    private BookId _bookId;
    private DateOnly _dueDate;

    private BorrowedBook()
    {
    }

    public BorrowedBook(BorrowedBookId id, CustomerId customerId, BookId bookId, DateOnly dueDate)
    {
        Id = id;
        _customerId = customerId;
        _bookId = bookId;
        _dueDate = dueDate;
    }
}