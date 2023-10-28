using Microsoft.EntityFrameworkCore;
using MyLibrary.Infrastructure.EntityFramework.Configurations;
using MyLibrary.Query.Models;

namespace MyLibrary.Infrastructure.EntityFramework.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<BookReadModel> Books { get; set; }
    public DbSet<BorrowedBookCopyReadModel> BorrowedBooks { get; set; }
    public DbSet<ReservedBookCopyReadModel> ReservedCopies { get; set; }
    public DbSet<CustomerReadModel> Customers { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("library");
            
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<BookReadModel>(configuration);
        modelBuilder.ApplyConfiguration<ReservedBookCopyReadModel>(configuration);
        modelBuilder.ApplyConfiguration<BorrowedBookCopyReadModel>(configuration);
        modelBuilder.ApplyConfiguration<CustomerReadModel>(configuration);
        modelBuilder.ApplyConfiguration<NotificationReadModel>(configuration);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}