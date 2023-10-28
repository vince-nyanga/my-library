using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Exceptions;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Application.Commands.Books;

public sealed record ReserveBook(Guid BookId) : ICommand;

internal sealed class ReserveBookHandler : ICommandHandler<ReserveBook>
{
    private readonly IUserContextProvider _userContextProvider;
    private readonly ICustomerRepository _customerRepository;
    private readonly IBookRepository _bookRepository;

    public ReserveBookHandler(IUserContextProvider userContextProvider, ICustomerRepository customerRepository, IBookRepository bookRepository)
    {
        _userContextProvider = userContextProvider;
        _customerRepository = customerRepository;
        _bookRepository = bookRepository;
    }

    public async ValueTask HandleAsync(ReserveBook command)
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
            book.ReserveCopy(customer.Id);
            await _bookRepository.SaveAsync(book);
        }
        catch (BookCopiesUnavailableException)
        {
            await WatchBookAsync(book, customer);
            throw;
        }
        catch (Exception e)
        {
            throw e.ToApplicationException();
        }
    }

    private async ValueTask WatchBookAsync(Book book, Customer customer)
    {
        customer.AddWatchedBook(book.Id, book.Title);
        await _customerRepository.UpdateAsync(customer);
    }
}