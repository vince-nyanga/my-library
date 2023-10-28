using System.Threading.Channels;
using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Api.BackgroundServices;

internal sealed class NotificationBrokerService : BackgroundService
{
    private readonly ChannelReader<IDomainEvent> _channelReader;
    private readonly IDomainEventDispatcher _domainEventDispatcher;

    public NotificationBrokerService(ChannelReader<IDomainEvent> channelReader, IDomainEventDispatcher domainEventDispatcher)
    {
        _channelReader = channelReader;
        _domainEventDispatcher = domainEventDispatcher;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await foreach (var domainEvent in _channelReader.ReadAllAsync(stoppingToken))
            {
                await _domainEventDispatcher.DispatchAsync(domainEvent);
            }
        }
    }
}