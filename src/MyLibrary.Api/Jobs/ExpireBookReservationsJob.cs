using Coravel.Invocable;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Commands.Books;

namespace MyLibrary.Api.Jobs;

internal sealed class ExpireBookReservationsJob : IInvocable
{
    private readonly ICommandDispatcher _commandDispatcher;

    public ExpireBookReservationsJob(ICommandDispatcher commandDispatcher)
        => _commandDispatcher = commandDispatcher;


    public async Task Invoke()
    {
        await _commandDispatcher.SendAsync(new ExpireBookReservations());
    }
}