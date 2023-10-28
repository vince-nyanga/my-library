using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class EmptyNotificationIdException : MyLibraryException
{
    public EmptyNotificationIdException()
        : base("Notification ID cannot be empty")
    {
    }
}