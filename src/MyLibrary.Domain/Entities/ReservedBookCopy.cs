using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

internal class ReservedBookCopy : Entity<ReservedBookId>
{
    private ReservedBookCopy()
    {
    }

    internal ReservedBookCopy(ReservedBookId id, BookId bookId, CustomerId customerId)
    {
        Id = id;
        BookId = bookId;
        CustomerId = customerId;
        ExpiryDate = DateTime.UtcNow;
    }

    public BookId BookId { get; init; }
    public CustomerId CustomerId { get; init; }
    public DateTime ExpiryDate { get; init; }
    
    public virtual Book Book { get; set; }
}