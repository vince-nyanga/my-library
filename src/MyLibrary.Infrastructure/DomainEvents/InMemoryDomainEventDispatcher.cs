using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Infrastructure.DomainEvents;

internal sealed class InMemoryDomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryDomainEventDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async ValueTask DispatchAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
    {
        using var serviceScope = _serviceProvider.CreateScope();
        var eventHandlers = serviceScope.ServiceProvider.GetServices<IDomainEventHandler<TEvent>>();

        var tasks = eventHandlers.Select(h => h.HandleAsync(domainEvent).AsTask());
        
        await Task.WhenAll(tasks);
    }
}