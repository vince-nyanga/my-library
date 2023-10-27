using MyLibrary.Domain.Entities;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Application.Abstractions.Repositories;

public interface IBookRepository
{
    ValueTask AddAsync(Book book);
    ValueTask<Book> GetAsync(BookId id);
}