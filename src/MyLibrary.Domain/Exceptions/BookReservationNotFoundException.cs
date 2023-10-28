using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class BookReservationNotFoundException : MyLibraryException
{
    public BookReservationNotFoundException(Guid bookId, Guid reservationId)
        : base($"Book {bookId} does not contain reservation with ID {reservationId}")
    {
    }
}