using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary.Query.Models;

namespace MyLibrary.Infrastructure.EntityFramework.Configurations;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<BookReadModel>, IEntityTypeConfiguration<ReservedBookCopyReadModel>, 
        IEntityTypeConfiguration<BorrowedBookCopyReadModel>, IEntityTypeConfiguration<CustomerReadModel>, IEntityTypeConfiguration<NotificationReadModel>
{
    public void Configure(EntityTypeBuilder<BookReadModel> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasMany(b => b.BorrowedCopies)
            .WithOne(b => b.Book)
            .HasForeignKey(b => b.BookId);
        
        builder.HasMany(b => b.ReservedCopies)
            .WithOne(b => b.Book)
            .HasForeignKey(r => r.BookId);

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
        
        builder.ToTable("Customers");
    }

    public void Configure(EntityTypeBuilder<NotificationReadModel> builder)
    {
        builder.HasKey(n => n.Id);
        builder.ToTable("Notifications");
    }
}