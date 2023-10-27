using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Abstractions.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.ValueObjects;
using MyLibrary.Infrastructure.EntityFramework.Contexts;

namespace MyLibrary.Infrastructure.Repositories;

internal sealed class SqlBookRepository : IBookRepository
{
    private readonly WriteDbContext _context;

    public SqlBookRepository(WriteDbContext context)
    {
        _context = context;
    }

    public async ValueTask AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async ValueTask<Book> GetAsync(BookId id)
    {
        return await _context.Books.SingleOrDefaultAsync(b => b.Id == id);
    }
}