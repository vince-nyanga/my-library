using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.Events;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Application.DomainEventHandlers;

internal sealed class BookCopyReturnedHandler : IDomainEventHandler<BookCopyReturned>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IWatchedBookRepository _watchedBookRepository;

    public BookCopyReturnedHandler(ICustomerRepository customerRepository,
        IWatchedBookRepository watchedBookRepository)
    {
        _customerRepository = customerRepository;
        _watchedBookRepository = watchedBookRepository;
    }

    public async ValueTask HandleAsync(BookCopyReturned domainEvent)
    {
        var customer = await _customerRepository.GetAsync(domainEvent.CustomerId);
        customer.SendNotification(
            $"You have returned a copy of {domainEvent.BookTitle}.");

        var watchedBooks = await _watchedBookRepository.GetForBookIdAsync(domainEvent.BookId);

        var updatedCustomers = new List<Customer>() { customer };

        foreach (var book in watchedBooks)
        {
            var watchingCustomer = book.Customer;
            var watchedBook = watchingCustomer.WatchedBooks
                .Single(b => b.BookId == new BookId(domainEvent.BookId));

            watchingCustomer.NotifyWatchedBookAvailability(watchedBook.BookId);
            updatedCustomers.Add(watchingCustomer);
        }

        await _customerRepository.UpdateManyAsync(updatedCustomers);
    }
}