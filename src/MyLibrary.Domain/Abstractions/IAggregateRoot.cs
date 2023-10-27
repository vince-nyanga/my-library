namespace MyLibrary.Domain.Abstractions;

public interface IAggregateRoot
{
    void ClearEvents();
    IReadOnlyCollection<IDomainEvent> Events { get; }
}