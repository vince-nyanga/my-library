using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Application.Abstractions.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.Events;

namespace MyLibrary.Application.DomainEventHandlers;

internal sealed class BookCopyReturnedHandler : IDomainEventHandler<BookCopyReturned>
{
    private readonly ICustomerRepository _repository;

    public BookCopyReturnedHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask HandleAsync(BookCopyReturned domainEvent)
    {
        var customer = await _repository.GetAsync(domainEvent.CustomerId);
        customer.SendNotification(
            $"You have returned a copy of {domainEvent.BookTitle}.");

        var watchedBooks = await _repository.GetWatchedBooksAsync(domainEvent.BookId);

        var updatedCustomers = new List<Customer>() { customer };
        foreach (var watchedBook in watchedBooks)
        {
            var watchingCustomer = watchedBook.Customer;
            watchingCustomer.NotifyWatchedBookAvailability(watchedBook.BookId);
            updatedCustomers.Add(watchingCustomer);
        }
        
        await _repository.UpdateManyAsync(updatedCustomers);
    }
}