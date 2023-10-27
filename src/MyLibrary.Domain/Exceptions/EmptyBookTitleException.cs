using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class EmptyBookTitleException : MyLibraryException
{
    public EmptyBookTitleException()
        : base("Book title cannot be null or empty")
    {
    }
}