using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Application.Abstractions.DomainEvents;

internal interface IDomainEventDispatcher
{
    ValueTask DispatchAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent;
}