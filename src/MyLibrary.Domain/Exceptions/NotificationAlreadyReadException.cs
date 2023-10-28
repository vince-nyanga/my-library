using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class NotificationAlreadyReadException : MyLibraryException
{
    public NotificationAlreadyReadException(Guid notificationId, string customerId)
        : base($"Notification {notificationId} for customer {customerId} is already read")
    {
    }
}