using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class EmptyBookIdException : MyLibraryException
{
    public EmptyBookIdException()
        : base("Book ID cannot be empty")
    {
    }
}