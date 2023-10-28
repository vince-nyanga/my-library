namespace MyLibrary.Query.Models;

public class NotificationReadModel
{
    public Guid Id { get; init; }
    public string CustomerId { get; init; }
    public string Message { get; init; }
    public DateTimeOffset SentDate { get; init; }
    public bool IsRead { get; init; }
    public DateTimeOffset? DateRead { get; init; }
}