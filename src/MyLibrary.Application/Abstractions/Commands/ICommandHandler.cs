namespace MyLibrary.Application.Abstractions.Commands;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    ValueTask HandleAsync(TCommand command);
}