using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Events;

namespace MyLibrary.Application.DomainEventHandlers;

internal sealed class BookReservationMadeHandler : IDomainEventHandler<BookReservationMade>
{
    private readonly ICustomerRepository _repository;

    public BookReservationMadeHandler(ICustomerRepository repository)
        => _repository = repository;

    public async ValueTask HandleAsync(BookReservationMade domainEvent)
    {
        var customer = await _repository.GetAsync(domainEvent.CustomerId);
        customer.SendNotification(
            $"You have reserved a copy of {domainEvent.BookTitle}. Your reservation expires on {domainEvent.ExpiryDate}");
        
        await _repository.UpdateAsync(customer);
    }
}