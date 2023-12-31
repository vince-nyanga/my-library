using Microsoft.EntityFrameworkCore;
using MyLibrary.Infrastructure.EntityFramework.Contexts;
using MyLibrary.Query;
using MyLibrary.Query.Models;

namespace MyLibrary.Infrastructure.Queries;

internal sealed class SqlBookQueryService : IBookQueryService
{
    private readonly ReadDbContext _context;

    public SqlBookQueryService(ReadDbContext context)
        => _context = context;

    public async ValueTask<IReadOnlyCollection<BookReadModel>> GetAllAsync()
    {
        return await _context.Books
            .Include(b => b.BorrowedCopies.Where(c => !c.IsReturned))
            .ToListAsync();
    }

    public async ValueTask<IReadOnlyCollection<BookReadModel>> SearchByTitleAsync(string searchTerm)
    {
        var searchPattern = $"%{searchTerm}%";
        return await _context.Books
            .Include(b => b.BorrowedCopies.Where(c => !c.IsReturned))
            .Where(b => EF.Functions.Like(b.Title, searchPattern))
            .ToListAsync();
    }

    public async ValueTask<IReadOnlyCollection<BorrowedBookCopyReadModel>> GetBorrowedBooksForCustomerAsync(
        string customerId)
    {
        return await _context.BorrowedBooks.Include(b => b.Book)
            .Where(b => !b.IsReturned && b.CustomerId == customerId)
            .ToListAsync();
    }

    public async ValueTask<IReadOnlyCollection<ReservedBookCopyReadModel>> GetReservedBooksForCustomerAsync(
        string customerId)
    {
        return await _context.ReservedCopies.Include(b => b.Book)
            .Where(b => b.CustomerId == customerId)
            .ToListAsync();
    }
}