using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

public sealed record NotificationMessage
{
    public NotificationMessage(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyNotificationMessageException();
        }
        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(NotificationMessage notificationMessage)
        => notificationMessage.Value;

    public static implicit operator NotificationMessage(string value)
        => new(value);
}