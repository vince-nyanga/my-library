using Microsoft.EntityFrameworkCore;
using MyLibrary.Infrastructure.EntityFramework.Contexts;
using MyLibrary.Query;
using MyLibrary.Query.Models;

namespace MyLibrary.Infrastructure.Queries;

internal sealed class SqlCustomerQueryService : ICustomerQueryService
{
    private readonly ReadDbContext _context;

    public SqlCustomerQueryService(ReadDbContext context)
        => _context = context;

    public async ValueTask<CustomerReadModel> GetByIdAsync(string id)
    {
        return await _context.Customers.Include(c => c.Notifications.Where(n => !n.IsRead))
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}