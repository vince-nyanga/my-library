namespace MyLibrary.Api.Responses.Books;

internal sealed record class BookResponse
{
    /// <summary>
    /// The book id.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// The book title.
    /// </summary>
    public string Title { get; init; }
    
    /// <summary>
    /// Total copies available in the library at the moment.
    /// </summary>
    public ushort AvailableCopies { get; init; }
    
    /// <summary>
    /// The closest date when a borrowed copy will be returned.
    /// </summary>
    public DateOnly? NextAvailableCopyDate { get; init; }
}