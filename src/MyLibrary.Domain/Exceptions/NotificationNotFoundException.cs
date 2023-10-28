using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class NotificationNotFoundException : MyLibraryException
{
    public NotificationNotFoundException(Guid notificationId, string customerId)
        : base($"Notification {notificationId} for customer {customerId} does not exist")
    {
    }
}