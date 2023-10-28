using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class EmptyBookReservationIdException : MyLibraryException
{
    public EmptyBookReservationIdException()
        : base("Book reservation ID cannot be empty")
    {
    }
}