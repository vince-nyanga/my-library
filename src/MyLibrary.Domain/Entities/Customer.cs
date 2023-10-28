using System.Collections.Immutable;
using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

internal sealed class Customer : AggregateRoot<CustomerId>
{
    private readonly List<Notification> _notifications = new();
    
    private Customer()
    {
    }

    public Customer(CustomerId id, CustomerName name, EmailAddress emailAddress)
    {
        Id = id;
        Name = name;
        EmailAddress = emailAddress;
    }
    
    public CustomerName Name { get; private set; }
    public EmailAddress EmailAddress { get; private set; }

    public IReadOnlyCollection<Notification> Notifications
    {
        get => _notifications.AsReadOnly();
        init => _notifications = value.ToList();
    }

    public void UpdateName(CustomerName name)
    {
        Name = name;
    }

    public void UpdateEmailAddress(EmailAddress emailAddress)
    {
        EmailAddress = emailAddress;
    }

    internal IReadOnlyCollection<Notification> UnreadNotifications
        => Notifications.Where(n => !n.IsRead).ToImmutableArray();

    public void MarkAsRead(NotificationId notificationId)
    {
        var notification = EnsureNotificationExists(notificationId);
        MarkAsRead(notification);
    }

    public void MarkAllAsRead()
    {
        foreach (var notification in UnreadNotifications)
        {
            MarkAsRead(notification);
        }
    }

    private void MarkAsRead(Notification notification)
        => notification.MarkAsRead();

    private Notification EnsureNotificationExists(NotificationId notificationId)
    {
        var notification = Notifications.SingleOrDefault(n => n.Id == notificationId);

        if (notification is null)
        {
            throw new NotificationNotFoundException(notificationId, Id);
        }

        return notification;
    }
}