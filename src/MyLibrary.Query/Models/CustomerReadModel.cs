namespace MyLibrary.Query.Models;

public sealed class CustomerReadModel
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string EmailAddress { get; init; }
    public IReadOnlyCollection<NotificationReadModel> Notifications { get; init; }
}