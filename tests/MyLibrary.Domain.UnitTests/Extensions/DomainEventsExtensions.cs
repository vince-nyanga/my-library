using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.UnitTests.Extensions;

internal static class DomainEventsExtensions
{
    public static TEvent FindRaisedEvent<TEvent>(this IReadOnlyCollection<IDomainEvent> events) where TEvent : class, IDomainEvent
    {
        return events.SingleOrDefault(e => e.GetType() == typeof(TEvent)) as TEvent;
    }
}