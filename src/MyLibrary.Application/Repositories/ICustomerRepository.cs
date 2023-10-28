using MyLibrary.Domain.Entities;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Application.Repositories;

internal interface ICustomerRepository
{
    ValueTask<Customer> GetAsync(CustomerId id);
    ValueTask AddAsync(Customer customer);
    ValueTask UpdateAsync(Customer customer);
    ValueTask<IReadOnlyCollection<Customer>> GetWithWatchedBooksAsync(BookId bookId);
    ValueTask UpdateManyAsync(List<Customer> customers);
}

internal interface IReservedBookRepository
{
    ValueTask<IReadOnlyCollection<ReservedBookCopy>> GetExpiredAsync();
}