using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Application.Abstractions.DomainEvents;

internal interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
{
    ValueTask HandleAsync(TEvent domainEvent);
}