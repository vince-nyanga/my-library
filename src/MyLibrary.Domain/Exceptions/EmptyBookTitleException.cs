using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class EmptyBookTitleException : MyLibraryException
{
    public EmptyBookTitleException()
        : base("Book title cannot be null or empty")
    {
    }
}