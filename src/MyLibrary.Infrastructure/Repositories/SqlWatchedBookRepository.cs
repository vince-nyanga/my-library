using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.ValueObjects;
using MyLibrary.Infrastructure.EntityFramework.Contexts;

namespace MyLibrary.Infrastructure.Repositories;

internal sealed class SqlWatchedBookRepository : IWatchedBookRepository
{
    private readonly WriteDbContext _context;

    public SqlWatchedBookRepository(WriteDbContext context)
        => _context = context;

    public async ValueTask<IReadOnlyCollection<WatchedBook>> GetForBookIdAsync(BookId bookId)
    {
        return await _context.WatchedBooks.Include(w => w.Customer)
            .Where(w => w.BookId == bookId)
            .ToListAsync();
    }
}