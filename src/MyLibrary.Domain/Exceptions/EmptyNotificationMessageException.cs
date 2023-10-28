using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class EmptyNotificationMessageException : MyLibraryException
{
    public EmptyNotificationMessageException()
        : base("Book title cannot be null or empty")
    {
    }
}