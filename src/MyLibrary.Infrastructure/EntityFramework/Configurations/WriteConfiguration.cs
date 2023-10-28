using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Infrastructure.EntityFramework.Configurations;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<Book>, IEntityTypeConfiguration<BookCopyReservation>, 
        IEntityTypeConfiguration<BorrowedBookCopy>, IEntityTypeConfiguration<Customer>, IEntityTypeConfiguration<Notification>
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
            .HasForeignKey(b => b.BookId);
        
        builder.HasMany(b => b.ReservedCopies)
            .WithOne()
            .HasForeignKey(r => r.BookId);

        builder.ToTable("Books");
    }

    public void Configure(EntityTypeBuilder<BookCopyReservation> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasConversion(id => id.Value, id => new BookReservationId(id));
        
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
            .HasForeignKey(c => c.CustomerId);

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
}