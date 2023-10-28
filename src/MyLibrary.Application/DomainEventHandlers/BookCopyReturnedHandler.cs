using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.Events;

namespace MyLibrary.Application.DomainEventHandlers;

internal sealed class BookCopyReturnedHandler : IDomainEventHandler<BookCopyReturned>
{
    private readonly ICustomerRepository _customerRepository;

    public BookCopyReturnedHandler(ICustomerRepository customerRepository)
        => _customerRepository = customerRepository;

    public async ValueTask HandleAsync(BookCopyReturned domainEvent)
    {
        var customer = await _customerRepository.GetAsync(domainEvent.CustomerId);
        customer.SendNotification(
            $"You have returned a copy of {domainEvent.BookTitle}.");

        var customers = await _customerRepository.GetWithWatchedBooksAsync(domainEvent.BookId);

        var updatedCustomers = new List<Customer>() { customer };

        foreach (var watchingCustomer in customers)
        {
            watchingCustomer.NotifyWatchedBookAvailability(domainEvent.BookId);
            updatedCustomers.Add(watchingCustomer);
        }

        await _customerRepository.UpdateManyAsync(updatedCustomers);
    }
}