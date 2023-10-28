using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Application.Abstractions.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.Events;

namespace MyLibrary.Application.DomainEventHandlers;

internal sealed class BookReservationCancelledHandler : IDomainEventHandler<BookReservationCancelled>
{
    private readonly ICustomerRepository _repository;

    public BookReservationCancelledHandler(ICustomerRepository repository)
        => _repository = repository;

    public async ValueTask HandleAsync(BookReservationCancelled domainEvent)
    {
        var watchedBooks = await _repository.GetWatchedBooksAsync(domainEvent.BookId);

        var updatedCustomers = new List<Customer>();
        foreach (var watchedBook in watchedBooks)
        {
            var watchingCustomer = watchedBook.Customer;
            watchingCustomer.NotifyWatchedBookAvailability(watchedBook.BookId);
            updatedCustomers.Add(watchingCustomer);
        }
        
        await _repository.UpdateManyAsync(updatedCustomers);
    }
}