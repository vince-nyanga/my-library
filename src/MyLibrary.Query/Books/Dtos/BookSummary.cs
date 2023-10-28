namespace MyLibrary.Query.Books.Dtos;

public sealed record BookSummary : Book
{
    
    public ushort TotalCopies { get; init; }
    public ushort AvailableCopies { get; init; }
    public DateOnly? NextAvailableCopyDate { get; init; }
}