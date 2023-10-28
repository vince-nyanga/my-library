using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Events;

namespace MyLibrary.Application.DomainEventHandlers;

internal sealed class BookCopyBorrowedHandler : IDomainEventHandler<BookCopyBorrowed>
{
    private readonly ICustomerRepository _repository;

    public BookCopyBorrowedHandler(ICustomerRepository repository)
        => _repository = repository;
    
    public async ValueTask HandleAsync(BookCopyBorrowed domainEvent)
    {
        var customer = await _repository.GetAsync(domainEvent.CustomerId);
        customer.SendNotification(
            $"You have borrowed a copy of {domainEvent.BookTitle}. The book is should be returned on {domainEvent.DueDate}");
        await _repository.UpdateAsync(customer);
    }
}