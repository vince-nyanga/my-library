using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Infrastructure.DomainEvents;

internal sealed class InMemoryDomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryDomainEventDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async ValueTask DispatchAsync(IDomainEvent domainEvent)
    {
        var eventType = domainEvent.GetType();
        var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(eventType);
        
        using var serviceScope = _serviceProvider.CreateScope();
        var eventHandlers = serviceScope.ServiceProvider.GetServices(handlerType);

        var tasks = eventHandlers.Select(h => ((ValueTask)handlerType
            .GetMethod(nameof(IDomainEventHandler<IDomainEvent>.HandleAsync))?
            .Invoke(h, new[] { domainEvent })).AsTask());
        
        await Task.WhenAll(tasks);
    }
}