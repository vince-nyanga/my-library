namespace MyLibrary.Query.Models;

public sealed class BookReadModel
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public ushort TotalCopies { get; set; }
    public ushort AvailableCopies { get; init; }
    public IReadOnlyCollection<BookCopyReservationReadModel> ReservedCopies { get; init; }
    public IReadOnlyCollection<BorrowedBookCopyReadModel> BorrowedCopies { get; init; }
}