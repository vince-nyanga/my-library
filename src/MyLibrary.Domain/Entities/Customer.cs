using System.Collections.Immutable;
using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class Customer : AggregateRoot<CustomerId>
{
    private CustomerName _name;
    private EmailAddress _emailAddress;
    private List<Notification> _notifications = new();

    private Customer()
    {
    }

    public Customer(CustomerId id, CustomerName name, EmailAddress emailAddress)
    {
        Id = id;
        _name = name;
        _emailAddress = emailAddress;
    }

    public IReadOnlyCollection<Notification> GetUnreadNotifications()
        => _notifications.Where(n => !n.IsRead).ToImmutableArray();

    public void MarkAsRead(NotificationId notificationId)
    {
        var notification = EnsureNotificationExists(notificationId);
        MarkAsRead(notification);
    }

    public void MarkAllAsRead()
    {
        foreach (var notification in GetUnreadNotifications())
        {
            MarkAsRead(notification);
        }
    }

    private void MarkAsRead(Notification notification)
        => notification.MarkAsRead();

    private Notification EnsureNotificationExists(NotificationId notificationId)
    {
        var notification = _notifications.SingleOrDefault(n => n.Id == notificationId);

        if (notification is null)
        {
            throw new NotificationNotFoundException(notificationId, Id);
        }

        return notification;
    }
}