using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class EmptyBorrowedBookIdException : MyLibraryException
{
    public EmptyBorrowedBookIdException()
        : base("Borrowed book ID cannot be empty")
    {
    }
}