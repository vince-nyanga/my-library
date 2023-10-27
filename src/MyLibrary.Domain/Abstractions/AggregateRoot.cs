namespace MyLibrary.Domain.Abstractions;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
{
    private readonly List<IDomainEvent> _events = new();
    
    public IReadOnlyCollection<IDomainEvent> Events => _events.AsReadOnly();
    
    public void ClearEvents()
    {
        _events.Clear();
    }

    protected void AddEvent(IDomainEvent domainEvent)
    {
        _events.Add(domainEvent);
    }
}