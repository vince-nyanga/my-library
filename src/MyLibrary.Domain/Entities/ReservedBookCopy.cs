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
        ExpiryDate = DateTimeOffset.UtcNow.AddHours(24); // this may need to be configurable, or use policies...
    }

    public BookId BookId { get; init; }
    public CustomerId CustomerId { get; init; }
    public DateTimeOffset ExpiryDate { get; init; }
}