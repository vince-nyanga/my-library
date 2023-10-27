using Microsoft.EntityFrameworkCore;
using MyLibrary.Domain.Entities;
using MyLibrary.Infrastructure.EntityFramework.Configurations;

namespace MyLibrary.Infrastructure.EntityFramework.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("library");
            
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<Book>(configuration);
        modelBuilder.ApplyConfiguration<BookCopyReservation>(configuration);
        modelBuilder.ApplyConfiguration<BorrowedBookCopy>(configuration);
        modelBuilder.ApplyConfiguration<Customer>(configuration);
    }
}