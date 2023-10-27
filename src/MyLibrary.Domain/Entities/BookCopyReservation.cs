using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class BookCopyReservation : Entity<BookReservationId>
{
    private BookCopyReservation()
    {
    }
    
    public BookCopyReservation(BookReservationId id, BookId bookId, CustomerId customerId)
    {
        Id = id;
        BookId = bookId;
        CustomerId = customerId;
    }
    
    public BookId BookId { get; private set; }
    public CustomerId CustomerId { get; private set; }
}