namespace MyLibrary.Query.Models;

internal sealed class NotificationReadModel
{
    public Guid Id { get; init; }
    public string CustomerId { get; init; }
    public string Message { get; init; }
    public DateTimeOffset SentDate { get; init; }
    public bool IsRead { get; init; }
    public DateTimeOffset? DateRead { get; init; }
}

internal sealed class WatchedBookReadModel
{
    public Guid Id { get; init; }
    public string CustomerId { get; init; }
    public Guid BookId { get; init; }
    public string BookTitle { get; init; }
}