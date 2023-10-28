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

        var bookTitleConverter = new ValueConverter<BookTitle, string>(t => t.Value, s => new BookTitle(s));

        builder.Property(typeof(ushort), "_availableCopies")
            .HasColumnName("AvailableCopies");
        
        builder.Property(typeof(ushort), "_totalCopies")
            .HasColumnName("TotalCopies");

        builder.Property(typeof(BookTitle), "_title")
            .HasConversion(bookTitleConverter)
            .HasColumnName("Title");
    
        builder.HasMany(typeof(BookCopyReservation), "_reservedCopies");
        builder.HasMany(typeof(BorrowedBookCopy), "_borrowedCopies");

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

        var customerNameConverter = new ValueConverter<CustomerName, string>(n => n.Value, n => new CustomerName(n));
        var emailAddressConverter = new ValueConverter<EmailAddress, string>(e => e.Value, e => new EmailAddress(e));

        builder.Property(typeof(CustomerName), "_name")
            .HasConversion(customerNameConverter)
            .HasColumnName("Name");
        
        builder.Property(typeof(EmailAddress), "_emailAddress")
            .HasConversion(emailAddressConverter)
            .HasColumnName("EmailAddress");
        
        builder.HasMany(typeof(Notification), "_notifications");

        builder.ToTable("Customers");
    }

    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(n => n.Id);
        builder.Property(n => n.Id)
            .HasConversion(id => id.Value, id => new NotificationId(id));

        var notificationMessageConverter =
            new ValueConverter<NotificationMessage, string>(m => m.Value, m => new NotificationMessage(m));
        var customerIdConverter = new ValueConverter<CustomerId, string>(id => id.Value, id => new CustomerId(id));

        builder.Property(n => n.Message)
            .HasConversion(m => m.Value, m => new NotificationMessage(m));

        builder.Property(n => n.CustomerId)
            .HasConversion(id => id.Value, id => new CustomerId(id));

        builder.ToTable("Notifications");
    }
}