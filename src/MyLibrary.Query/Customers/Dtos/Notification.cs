namespace MyLibrary.Query.Customers.Dtos;

public sealed record Notification
{
    public Guid Id { get; init; }
    public string Message { get; set; }
    public DateTimeOffset SentDate { get; set; }
};