using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class EmptyBorrowedBookIdException : MyLibraryException
{
    public EmptyBorrowedBookIdException()
        : base("Borrowed book ID cannot be empty")
    {
    }
}