using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Application.Abstractions.DomainEvents;

public interface IDomainEventDispatcher
{
    ValueTask DispatchAsync(IDomainEvent domainEvent);
}