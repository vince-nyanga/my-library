using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class Notification : Entity<NotificationId>
{
    public Notification(NotificationId id, CustomerId customerId, NotificationMessage message)
    {
        Id = id;
        CustomerId = customerId;
        Message = message;
        IsRead = false;
    }

    public CustomerId CustomerId { get; init; }
    public NotificationMessage Message { get; init; }
    public DateTimeOffset SentDate { get; init; }
    public bool IsRead { get; private set; }
    public DateTimeOffset? DateRead { get; private set; }

    public void MarkAsRead()
    {
        if (IsRead)
        {
            throw new NotificationAlreadyReadException(Id, CustomerId);
        }
        
        IsRead = true;
        DateRead = DateTimeOffset.UtcNow;
    }
}