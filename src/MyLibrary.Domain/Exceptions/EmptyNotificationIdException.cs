using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class EmptyNotificationIdException : MyLibraryException
{
    public EmptyNotificationIdException()
        : base("Notification ID cannot be empty")
    {
    }
}