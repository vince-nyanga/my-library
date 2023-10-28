using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary.Query.Models;

namespace MyLibrary.Infrastructure.EntityFramework.Configurations;

/// <summary>
/// NOTE: This is almost a 'violation' of Single Responsibility, depending on who you ask of course 😜.
/// </summary>
internal sealed class ReadConfiguration : IEntityTypeConfiguration<BookReadModel>, IEntityTypeConfiguration<ReservedBookCopyReadModel>, 
        IEntityTypeConfiguration<BorrowedBookCopyReadModel>, IEntityTypeConfiguration<CustomerReadModel>, IEntityTypeConfiguration<NotificationReadModel>,
        IEntityTypeConfiguration<WatchedBookReadModel>
{
    public void Configure(EntityTypeBuilder<BookReadModel> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasMany(b => b.BorrowedCopies)
            .WithOne(b => b.Book)
            .HasForeignKey(b => b.BookId)
            .IsRequired();
        
        builder.HasMany(b => b.ReservedCopies)
            .WithOne(b => b.Book)
            .HasForeignKey(r => r.BookId)
            .IsRequired();

        builder.ToTable("Books");
    }

    public void Configure(EntityTypeBuilder<ReservedBookCopyReadModel> builder)
    {
        builder.HasKey(b => b.Id);
        builder.ToTable("ReservedCopies");
    }

    public void Configure(EntityTypeBuilder<BorrowedBookCopyReadModel> builder)
    {
        builder.HasKey(b => b.Id);
        builder.ToTable("BorrowedCopies");
    }

    public void Configure(EntityTypeBuilder<CustomerReadModel> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.Notifications)
            .WithOne()
            .HasForeignKey(n => n.CustomerId);

        builder.HasMany(c => c.WatchedBooks)
            .WithOne()
            .HasForeignKey(w => w.CustomerId)
            .IsRequired();
        
        builder.ToTable("Customers");
    }

    public void Configure(EntityTypeBuilder<NotificationReadModel> builder)
    {
        builder.HasKey(n => n.Id);
        builder.ToTable("Notifications");
    }

    public void Configure(EntityTypeBuilder<WatchedBookReadModel> builder)
    {
        builder.HasKey(w => w.Id);
        builder.ToTable("WatchedBooks");
    }
}