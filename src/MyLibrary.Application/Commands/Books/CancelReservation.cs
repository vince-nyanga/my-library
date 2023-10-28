using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Exceptions;
using MyLibrary.Application.Repositories;

namespace MyLibrary.Application.Commands.Books;

public sealed record CancelReservation(Guid BookId) : ICommand;

internal sealed class CancelReservationHandler : ICommandHandler<CancelReservation>
{
    private readonly IUserContextProvider _userContextProvider;
    private readonly ICustomerRepository _customerRepository;
    private readonly IBookRepository _bookRepository;

    public CancelReservationHandler(
        IUserContextProvider userContextProvider,
        ICustomerRepository customerRepository,
        IBookRepository bookRepository)
    {
        _userContextProvider = userContextProvider;
        _customerRepository = customerRepository;
        _bookRepository = bookRepository;
    }

    public async ValueTask HandleAsync(CancelReservation command)
    {
        var customer = await _customerRepository.GetAsync(_userContextProvider.UserId);
        if (customer is null)
        {
            throw new EntityNotFoundException(
                $"There is no record for customer with ID {_userContextProvider.UserId}. Please update your profile");
        }

        var book = await _bookRepository.GetAsync(command.BookId);
        if (book is null)
        {
            throw new EntityNotFoundException(
                $"Book with ID {command.BookId} does not exist");
        }

        try
        {
            book.CancelReservation(customer.Id);
            await _bookRepository.SaveAsync(book);
        }
        catch (Exception e)
        {
            throw e.ToApplicationException();
        }
    }
}