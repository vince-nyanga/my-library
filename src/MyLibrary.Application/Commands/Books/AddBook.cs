using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Abstractions.Repositories;
using MyLibrary.Application.Constants;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Application.Commands.Books;

public sealed record AddBook(Guid Id, string Title, ushort TotalCopies) : ICommand;

internal sealed class AddBookHandler : ICommandHandler<AddBook>
{
    private readonly IBookRepository _repository;
    private readonly IUserContextProvider _userContextProvider;

    public AddBookHandler(IBookRepository repository, IUserContextProvider userContextProvider)
    {
        _repository = repository;
        _userContextProvider = userContextProvider;
    }

    public async ValueTask HandleAsync(AddBook command)
    {
        EnsureUserIsAllowedToAddBooks();
        
        
        var book = new Book(command.Id, command.Title, command.TotalCopies);
        await _repository.AddAsync(book);
    }

    private void EnsureUserIsAllowedToAddBooks()
    {
        if (!_userContextProvider.Permissions.Contains(Permissions.AddBooks))
        {
            throw new ForbiddenActionException("User is not allowed to add books");
        }
    }
}