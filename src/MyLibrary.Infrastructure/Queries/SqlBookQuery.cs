using Microsoft.EntityFrameworkCore;
using MyLibrary.Infrastructure.EntityFramework.Contexts;
using MyLibrary.Query;
using MyLibrary.Query.Models;

namespace MyLibrary.Infrastructure.Queries;

internal sealed class SqlBookQuery : IBookQuery
{
    private readonly ReadDbContext _context;

    public SqlBookQuery(ReadDbContext context)
    {
        _context = context;
    }

    public async ValueTask<IEnumerable<BookReadModel>>GetAllAsync()
    {
        return await _context.Books.AsNoTracking().ToListAsync();
    }
}