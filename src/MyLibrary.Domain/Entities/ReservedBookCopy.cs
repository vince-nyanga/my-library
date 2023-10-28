using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

internal sealed class ReservedBookCopy : Entity<ReservedBookId>
{
    private ReservedBookCopy()
    {
    }

    internal ReservedBookCopy(ReservedBookId id, BookId bookId, CustomerId customerId)
    {
        Id = id;
        BookId = bookId;
        CustomerId = customerId;
        ExpiryDate = DateTime.UtcNow.AddHours(24);
    }

    public BookId BookId { get; init; }
    public CustomerId CustomerId { get; init; }
    public DateTime ExpiryDate { get; init; }
}