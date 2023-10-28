using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.Events;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Application.DomainEventHandlers;

internal sealed class BookReservationCancelledHandler : IDomainEventHandler<BookReservationCancelled>
{
    private readonly ICustomerRepository _customerRepository;

    public BookReservationCancelledHandler(ICustomerRepository customerRepository)
        => _customerRepository = customerRepository;

    public async ValueTask HandleAsync(BookReservationCancelled domainEvent)
    {
        var customer = await _customerRepository.GetAsync(domainEvent.CustomerId);
        customer.SendNotification(
            $"You have cancelled your reservation of {domainEvent.BookTitle}.");

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