using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.ValueObjects;
using MyLibrary.Infrastructure.EntityFramework.Contexts;

namespace MyLibrary.Infrastructure.Repositories;

internal sealed class SqlBookRepository : IBookRepository
{
    private readonly WriteDbContext _context;

    public SqlBookRepository(WriteDbContext context)
        => _context = context;

    public async ValueTask AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAndDispatchEventsAsync();
    }

    public async ValueTask<Book> GetAsync(BookId id)
    {
        return await _context.Books
            .Include(b => b.ReservedCopies)
            .Include(b => b.BorrowedCopies.Where(c => !c.IsReturned))
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async ValueTask SaveAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAndDispatchEventsAsync();
    }

    public async ValueTask<IReadOnlyCollection<Book>> GetWithExpiredReservationsAsync()
    {
        return await _context.Books
            .Include(b => b.BorrowedCopies.Where(c => !c.IsReturned))
            .Include(b => b.ReservedCopies)
            .Where(b => b.ReservedCopies.Select(c => c.ExpiryDate < DateTime.UtcNow).Any())
            .ToListAsync();
    }

    public async ValueTask SaveManyAsync(IReadOnlyCollection<Book> books)
    {
        foreach (var book in books)
        {
            _context.Books.Update(book);
        }

        await _context.SaveChangesAndDispatchEventsAsync();
    }
}