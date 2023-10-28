namespace MyLibrary.Query.Models;

internal sealed class BookCopyReservationReadModel
{
    public Guid Id { get; init; }
    public Guid BookId { get; init; }
    public string CustomerId { get; init; }
    public DateTimeOffset DateReserved { get; init; }
}