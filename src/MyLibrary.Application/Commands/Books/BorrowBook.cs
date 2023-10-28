using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Abstractions.Repositories;
using MyLibrary.Application.Exceptions;

namespace MyLibrary.Application.Commands.Books;

public record BorrowBook(Guid BookId, DateOnly ReturnDate) : ICommand;

internal sealed class ReserveBookHandler : ICommandHandler<BorrowBook>
{
    private readonly IUserContextProvider _userContextProvider;
    private readonly ICustomerRepository _customerRepository;
    private readonly IBookRepository _bookRepository;

    public ReserveBookHandler(
        IUserContextProvider userContextProvider, ICustomerRepository customerRepository, IBookRepository bookRepository)
    {
        _userContextProvider = userContextProvider;
        _customerRepository = customerRepository;
        _bookRepository = bookRepository;
    }

    public async ValueTask HandleAsync(BorrowBook command)
    {
        var customer = await _customerRepository.GetAsync(_userContextProvider.UserId);

        if (customer is null)
        {
            throw new EntityNotFoundException(
                $"There is no record for customer with Id {_userContextProvider.UserId}. Please update your profile");
        }

        var book = await _bookRepository.GetAsync(command.BookId);

        if (book is null)
        {
            throw new EntityNotFoundException(
                $"Book with id {command.BookId} does not exist");
        }

        try
        {
            book.BorrowCopy(customer, command.ReturnDate);
            await _bookRepository.SaveAsync(book);
        }
        catch (Exception e)
        {
            throw e.ToApplicationException();
        }
    }
}