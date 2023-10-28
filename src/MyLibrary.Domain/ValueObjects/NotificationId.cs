using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

internal sealed record NotificationId
{
    public NotificationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyNotificationIdException();
        }
        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(NotificationId notificationId)
        => notificationId.Value;

    public static implicit operator NotificationId(Guid value)
        => new(value);
}