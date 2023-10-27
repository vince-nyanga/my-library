using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class BookReservationNotFoundException : MyLibraryException
{
    public BookReservationNotFoundException(Guid bookId, Guid reservationId)
        : base($"Book {bookId} does not contain reservation with ID {reservationId}")
    {
    }
}