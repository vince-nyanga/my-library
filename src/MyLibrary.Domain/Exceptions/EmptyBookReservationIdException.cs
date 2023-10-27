using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class EmptyBookReservationIdException : MyLibraryException
{
    public EmptyBookReservationIdException()
        : base("Book reservation ID cannot be empty")
    {
    }
}