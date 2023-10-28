namespace MyLibrary.Query.Books.Dtos;

public record BookSummary
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public ushort TotalCopies { get; init; }
    public ushort AvailableCopies { get; init; }
    public DateOnly? NextAvailableCopyDate { get; init; }
}