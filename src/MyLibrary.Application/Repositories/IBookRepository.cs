using MyLibrary.Domain.Entities;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Application.Repositories;

internal interface IBookRepository
{
    ValueTask AddAsync(Book book);
    ValueTask<Book> GetAsync(BookId id);
    ValueTask SaveAsync(Book book);
    ValueTask<IReadOnlyCollection<Book>> GetWithExpiredReservationsAsync();
    ValueTask SaveManyAsync(IReadOnlyCollection<Book> books);
}