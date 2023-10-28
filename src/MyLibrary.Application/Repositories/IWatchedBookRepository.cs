using MyLibrary.Domain.Entities;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Application.Repositories;

internal interface IWatchedBookRepository
{
    ValueTask<IReadOnlyCollection<WatchedBook>> GetForBookIdAsync(BookId bookId);
}