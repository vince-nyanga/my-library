using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Entities;
using MyLibrary.Infrastructure.EntityFramework.Configurations;

namespace MyLibrary.Infrastructure.EntityFramework.Contexts;

internal sealed class WriteDbContext : DbContext
{
    private readonly IDomainEventDispatcher _domainEventDispatcher;
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
    public WriteDbContext(DbContextOptions<WriteDbContext> options, IDomainEventDispatcher domainEventDispatcher)
        : base(options)
    {
        _domainEventDispatcher = domainEventDispatcher;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("library");
            
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<Book>(configuration);
        modelBuilder.ApplyConfiguration<BookCopyReservation>(configuration);
        modelBuilder.ApplyConfiguration<BorrowedBookCopy>(configuration);
        modelBuilder.ApplyConfiguration<Customer>(configuration);
        modelBuilder.ApplyConfiguration<Notification>(configuration);
    }
    
    public async Task SaveChangesAndDispatchEventsAsync()
    {
        var domainEvents = ChangeTracker.Entries<IAggregateRoot>()
            .Select(entityEntry => entityEntry.Entity)
            .Where(aggregateRoot => aggregateRoot.Events.Any())
            .SelectMany(a => a.Events)
            .ToArray();

        await SaveChangesAsync();

        await Task.WhenAll(domainEvents.Select(e => _domainEventDispatcher.DispatchAsync(e).AsTask()));
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        var domainEventEntities = ChangeTracker.Entries<IAggregateRoot>()
            .Select(entityEntry => entityEntry.Entity)
            .Where(aggregateRoot => aggregateRoot.Events.Any())
            .ToArray();
        
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        
        
    }
}