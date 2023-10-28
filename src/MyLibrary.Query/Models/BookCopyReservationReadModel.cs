namespace MyLibrary.Query.Models;

public sealed class BookCopyReservationReadModel
{
    public Guid Id { get; init; }
    public Guid BookId { get; init; }
    public Guid CustomerId { get; init; }
    public DateTimeOffset DateReserved { get; init; }
}