using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Application.Abstractions.DomainEvents;

public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
{
    ValueTask HandleAsync(TEvent domainEvent);
}