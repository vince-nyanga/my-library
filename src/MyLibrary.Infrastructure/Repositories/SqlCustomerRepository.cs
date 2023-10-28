using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.ValueObjects;
using MyLibrary.Infrastructure.EntityFramework.Contexts;

namespace MyLibrary.Infrastructure.Repositories;

internal sealed class SqlCustomerRepository : ICustomerRepository
{
    private readonly WriteDbContext _context;

    public SqlCustomerRepository(WriteDbContext context)
        => _context = context;

    public async ValueTask<Customer> GetAsync(CustomerId id)
    {
        return await _context.Customers
            .Include(c => c.Notifications.Where(n => !n.IsRead))
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async ValueTask AddAsync(Customer customer)
    {
        await _context.AddAsync(customer);
        await _context.SaveChangesAndDispatchEventsAsync();
    }

    public async ValueTask UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAndDispatchEventsAsync();
    }
    
    public async ValueTask<IReadOnlyCollection<Customer>> GetWithWatchedBooksAsync(BookId bookId)
    {
        return await _context.Customers
            .Include(b => b.WatchedBooks.Where(w => w.BookId == bookId))
            .Where(b => b.WatchedBooks.Count > 0)
            .ToListAsync();
    }

    public async ValueTask UpdateManyAsync(List<Customer> customers)
    {
        foreach (var customer in customers)
        {
            _context.Customers.Update(customer);
        }

        await _context.SaveChangesAndDispatchEventsAsync();
    }
}