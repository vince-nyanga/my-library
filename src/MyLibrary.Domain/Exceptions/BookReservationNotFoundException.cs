using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class BookReservationNotFoundException : MyLibraryException
{
    public BookReservationNotFoundException(Guid bookId, string customerId)
        : base($"Book {bookId} does not contain reservation for customer {customerId}")
    {
    }
}