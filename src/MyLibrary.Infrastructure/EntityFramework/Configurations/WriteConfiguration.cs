using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Infrastructure.EntityFramework.Configurations;

/// <summary>
/// NOTE: This is almost a 'violation' of Single Responsibility, depending on who you ask of course.
/// </summary>
internal sealed class WriteConfiguration : IEntityTypeConfiguration<Book>, IEntityTypeConfiguration<ReservedBookCopy>, 
        IEntityTypeConfiguration<BorrowedBookCopy>, IEntityTypeConfiguration<Customer>, IEntityTypeConfiguration<Notification>,
        IEntityTypeConfiguration<WatchedBook>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasConversion(id => id.Value, id => new BookId(id));

        builder.Property(b => b.Title)
            .HasConversion(t => t.Value, s => new BookTitle(s));
    
        builder.HasMany(b => b.BorrowedCopies)
            .WithOne()
            .HasForeignKey(b => b.BookId)
            .IsRequired();
        
        builder.HasMany(b => b.ReservedCopies)
            .WithOne()
            .HasForeignKey(r => r.BookId)
            .IsRequired();

        builder.Ignore(b => b.CopiesNotReturned);

        builder.HasData(GetBookSeedData());

        builder.ToTable("Books");
    }

    public void Configure(EntityTypeBuilder<ReservedBookCopy> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasConversion(id => id.Value, id => new ReservedBookId(id));
        
        builder.Property(b => b.BookId)
            .HasConversion(id => id.Value, id => new BookId(id));

        builder.Property(b => b.CustomerId)
            .HasConversion(id => id.Value, id => new CustomerId(id));

        builder.ToTable("ReservedCopies");
    }

    public void Configure(EntityTypeBuilder<BorrowedBookCopy> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasConversion(id => id.Value, id => new BorrowedBookId(id));
        
        builder.Property(b => b.BookId)
            .HasConversion(id => id.Value, id => new BookId(id));

        builder.Property(b => b.CustomerId)
            .HasConversion(id => id.Value, id => new CustomerId(id));

        builder.ToTable("BorrowedCopies");
    }

    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(b => b.Id)
            .HasConversion(id => id.Value, id => new CustomerId(id));

        builder.Property(c => c.Name)
            .HasConversion(n => n.Value, n => new CustomerName(n));

        builder.Property(c => c.EmailAddress)
            .HasConversion(e => e.Value, e => new EmailAddress(e));

        builder.HasMany(c => c.Notifications)
            .WithOne()
            .HasForeignKey(c => c.CustomerId)
            .IsRequired();

        builder.HasMany(c => c.WatchedBooks)
            .WithOne()
            .HasForeignKey(w => w.CustomerId)
            .IsRequired();

        builder.ToTable("Customers");
    }

    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(n => n.Id);
        builder.Property(n => n.Id)
            .HasConversion(id => id.Value, id => new NotificationId(id));
        
        builder.Property(n => n.Message)
            .HasConversion(m => m.Value, m => new NotificationMessage(m));

        builder.Property(n => n.CustomerId)
            .HasConversion(id => id.Value, id => new CustomerId(id));
        
        
        builder.ToTable("Notifications");
    }
    
    public void Configure(EntityTypeBuilder<WatchedBook> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Id)
            .HasConversion(id => id.Value, id => new WatchedBookId(id));
        
        builder.Property(n => n.CustomerId)
            .HasConversion(id => id.Value, id => new CustomerId(id));
        
        builder.Property(n => n.BookId)
            .HasConversion(id => id.Value, id => new BookId(id));

        builder.ToTable("WatchedBooks");
    }

    private static IEnumerable<Book> GetBookSeedData()
    {
        yield return new Book(
            id: Guid.Parse("39A2D02A-FE6E-45F7-9906-4B5C3FF972EB"), 
            title: "The Secrets To System Design",
            totalCopies: 1);
        
        yield return new Book(
            id: Guid.Parse("FF24B552-A6E3-4BFF-98DB-E3C64C1ED854"), 
            title: "Domain Driven Design",
            totalCopies: 5);
        
        yield return new Book(
            id: Guid.Parse("6538A089-F495-41CE-9203-96C9A9B7B749"), 
            title: "Clean Architecture",
            totalCopies: 2);
        
        yield return new Book(
            id: Guid.Parse("C6805347-B3E7-4D37-88CF-B6669B92B447"), 
            title: "CQRS In Practice",
            totalCopies: 10);
        
        yield return new Book(
            id: Guid.Parse("BA846FDB-22AB-41EC-8694-85AAAB6CC75E"), 
            title: "Waiting For The Rains",
            totalCopies: 7);
    }
}