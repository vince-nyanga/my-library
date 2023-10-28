using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Application.Abstractions.Repositories;
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
        await _repository.UpdateAsync(customer);
    }
}