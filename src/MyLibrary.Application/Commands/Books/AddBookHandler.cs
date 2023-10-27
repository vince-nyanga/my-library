using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Abstractions.Repositories;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Application.Commands.Books;

internal sealed class AddBookHandler : ICommandHandler<AddBook>
{
    private readonly IBookRepository _repository;

    public AddBookHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask HandleAsync(AddBook command)
    {
        var book = new Book(command.Id, command.Title, command.TotalCopies);
        await _repository.AddAsync(book);
    }
}