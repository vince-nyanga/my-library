using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Infrastructure.Exceptions;

namespace MyLibrary.Infrastructure.Commands;

/// <summary>
/// I could have used other options such as MediatR to dispatch the commands,
/// but I opted for something simple.
/// </summary>
internal sealed class InMemoryCommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async ValueTask SendAsync<TCommand>(TCommand command) where TCommand : ICommand
    {
        using var serviceScope = _serviceProvider.CreateScope();
        var commandHandler = serviceScope.ServiceProvider.GetService<ICommandHandler<TCommand>>();

        if (commandHandler is null)
        {
            throw new CommandHandlerNotDefinedException(typeof(TCommand));
        }

        await commandHandler.HandleAsync(command);
    }
}