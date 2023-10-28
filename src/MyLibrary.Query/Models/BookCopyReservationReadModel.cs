namespace MyLibrary.Query.Models;

internal class BookCopyReservationReadModel
{
    public Guid Id { get; init; }
    public Guid BookId { get; init; }
    public string CustomerId { get; init; }
    public DateTimeOffset DateReserved { get; init; }
    
    public virtual BookReadModel Book { get; set; }
}