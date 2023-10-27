using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class EmptyBookIdException : MyLibraryException
{
    public EmptyBookIdException()
        : base("Book ID cannot be empty")
    {
    }
}