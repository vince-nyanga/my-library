using Microsoft.EntityFrameworkCore;
using MyLibrary.Infrastructure.EntityFramework.Configurations;
using MyLibrary.Query.Models;

namespace MyLibrary.Infrastructure.EntityFramework.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<BookReadModel> Books { get; set; }
    public DbSet<CustomerReadModel> Customers { get; set; }

    public ReadDbContext(DbContextOptions<WriteDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("library");
            
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<BookReadModel>(configuration);
        modelBuilder.ApplyConfiguration<BookCopyReservationReadModel>(configuration);
        modelBuilder.ApplyConfiguration<BorrowedBookCopyReadModel>(configuration);
        modelBuilder.ApplyConfiguration<CustomerReadModel>(configuration);
    }
}