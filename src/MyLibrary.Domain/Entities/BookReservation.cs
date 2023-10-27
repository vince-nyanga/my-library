using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class BookReservation : Entity<BookReservationId>
{
    private BookReservation()
    {
    }
    
    public BookReservation(BookReservationId id)
    {
        Id = id;
    }
}