namespace MyLibrary.Application.Abstractions.Commands;

public interface ICommandDispatcher
{
    ValueTask SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
}