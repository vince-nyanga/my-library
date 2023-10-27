using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary.Query.Models;

namespace MyLibrary.Infrastructure.EntityFramework.Configurations;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<BookReadModel>, IEntityTypeConfiguration<BookCopyReservationReadModel>, 
        IEntityTypeConfiguration<BorrowedBookCopyReadModel>, IEntityTypeConfiguration<CustomerReadModel>
{
    public void Configure(EntityTypeBuilder<BookReadModel> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasMany<BookCopyReservationReadModel>();
        builder.HasMany<BorrowedBookCopyReadModel>();

        builder.ToTable("Books");
    }

    public void Configure(EntityTypeBuilder<BookCopyReservationReadModel> builder)
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
        builder.ToTable("Customers");
    }
}