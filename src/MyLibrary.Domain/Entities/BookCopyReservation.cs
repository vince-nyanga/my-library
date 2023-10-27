using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class BookCopyReservation : Entity<BookReservationId>
{
    private BookCopyReservation()
    {
    }

    internal BookCopyReservation(BookReservationId id, BookId bookId, CustomerId customerId)
    {
        Id = id;
        BookId = bookId;
        CustomerId = customerId;
        DateReserved = DateTimeOffset.UtcNow;
    }

    public BookId BookId { get; init; }
    public CustomerId CustomerId { get; init; }
    public DateTimeOffset DateReserved { get; init; }
}