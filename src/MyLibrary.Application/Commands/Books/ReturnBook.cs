using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Abstractions.Repositories;
using MyLibrary.Application.Exceptions;

namespace MyLibrary.Application.Commands.Books;

public sealed record ReturnBook(Guid BookId) : ICommand;

internal sealed class ReturnBookHandler : ICommandHandler<ReturnBook>
{
    private readonly IUserContextProvider _userContextProvider;
    private readonly IBookRepository _repository;

    public ReturnBookHandler(IUserContextProvider userContextProvider, IBookRepository repository)
    {
        _userContextProvider = userContextProvider;
        _repository = repository;
    }

    public async ValueTask HandleAsync(ReturnBook command)
    {
        var book = await _repository.GetAsync(command.BookId);

        if (book is null)
        {
            throw new EntityNotFoundException($"Book with ID {command.BookId} does not exist");
        }

        var borrowedCopy =
            book.BorrowedCopies.SingleOrDefault(c => c.CustomerId == _userContextProvider.UserId && !c.IsReturned);

        if (borrowedCopy is null)
        {
            throw new EntityNotFoundException($"User {_userContextProvider.UserId} does not have a borrowed copy for book {command.BookId}");
        }
        
        book.ReturnCopy(borrowedCopy.Id);

        await _repository.SaveAsync(book);
    }
}