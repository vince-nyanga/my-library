using System.Collections.Immutable;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Entities;
using MyLibrary.Infrastructure.EntityFramework.Configurations;

namespace MyLibrary.Infrastructure.EntityFramework.Contexts;

internal sealed class WriteDbContext : DbContext
{
    private readonly ChannelWriter<IDomainEvent> _channelWriter;

    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
    public WriteDbContext(DbContextOptions<WriteDbContext> options, ChannelWriter<IDomainEvent> channelWriter)
        : base(options)
    {
        _channelWriter = channelWriter;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("library");
            
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<Book>(configuration);
        modelBuilder.ApplyConfiguration<ReservedBookCopy>(configuration);
        modelBuilder.ApplyConfiguration<BorrowedBookCopy>(configuration);
        modelBuilder.ApplyConfiguration<Customer>(configuration);
        modelBuilder.ApplyConfiguration<Notification>(configuration);
    }
    
    public async Task SaveChangesAndDispatchEventsAsync()
    {
        var aggregateRoots = ChangeTracker.Entries<IAggregateRoot>()
            .Select(entityEntry => entityEntry.Entity)
            .Where(aggregateRoot => aggregateRoot.Events.Any())
            .ToArray();

        var domainEvents = aggregateRoots.SelectMany(a => a.Events.ToImmutableArray());
        
        await SaveChangesAsync();

        await Task.WhenAll(domainEvents.Select(e => _channelWriter.WriteAsync(e).AsTask()));
        
        foreach (var aggregateRoot in aggregateRoots)
        {
            aggregateRoot.ClearEvents();
        }
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