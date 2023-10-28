using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Infrastructure.EntityFramework.Contexts;

namespace MyLibrary.Infrastructure.Repositories;

internal sealed class SqlReservedBookRepository : IReservedBookRepository
{
    private readonly WriteDbContext _context;

    public SqlReservedBookRepository(WriteDbContext context)
        => _context = context;

    public async ValueTask<IReadOnlyCollection<ReservedBookCopy>> GetExpiredAsync()
    {
        var date = DateTime.UtcNow;
        return await _context.ReservedBooks.Include(r => r.Book)
            .Where(r => r.ExpiryDate <= date)
            .ToListAsync();
    }
}