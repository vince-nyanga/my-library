using System.Collections.Immutable;
using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

internal sealed class Customer : AggregateRoot<CustomerId>
{
    private readonly List<Notification> _notifications = new();
    private readonly List<WatchedBook> _watchedBooks = new();

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

    public IReadOnlyCollection<WatchedBook> WatchedBooks
    {
        get => _watchedBooks.AsReadOnly();
        init => _watchedBooks = value.ToList();
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

    public void SendNotification(NotificationMessage message)
    {
        _notifications.Add(new Notification(Guid.NewGuid(), Id, message));
    }
    
    public void MarkNotificationAsRead(NotificationId notificationId)
    {
        var notification = EnsureNotificationExists(notificationId);
        MarkAsRead(notification);
    }

    public void MarkAllNotificationsAsRead()
    {
        foreach (var notification in UnreadNotifications)
        {
            MarkAsRead(notification);
        }
    }

    public void AddWatchedBook(BookId bookId, BookTitle bookTitle)
    {
        if (_watchedBooks.Any(b => b.BookId == bookId))
        {
            return;
        }
        
        _watchedBooks.Add(new WatchedBook(Guid.NewGuid(), Id, bookId, bookTitle));
    }

    public void NotifyWatchedBookAvailability(BookId bookId)
    {
        var watchedBook = _watchedBooks.SingleOrDefault(b => b.BookId == bookId);

        if (watchedBook is not null)
        {
            _watchedBooks.Remove(watchedBook);
            _notifications.Add(new Notification(Guid.NewGuid(), Id, $"The book you wanted: '{watchedBook.BookTitle}' is now available."));
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