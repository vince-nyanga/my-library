using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.Events;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Application.DomainEventHandlers;

internal sealed class BookReservationExpiredHandler : IDomainEventHandler<BookReservationExpired>
{
    private readonly IWatchedBookRepository _watchedBookRepository;
    private readonly ICustomerRepository _customerRepository;

    public BookReservationExpiredHandler(IWatchedBookRepository watchedBookRepository,
        ICustomerRepository customerRepository)
    {
        _watchedBookRepository = watchedBookRepository;
        _customerRepository = customerRepository;
    }

    public async ValueTask HandleAsync(BookReservationExpired domainEvent)
    {
        var watchedBooks = await _watchedBookRepository.GetForBookIdAsync(domainEvent.BookId);

        var updatedCustomers = new List<Customer>();

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