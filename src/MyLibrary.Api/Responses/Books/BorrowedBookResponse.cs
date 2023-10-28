using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Responses.Books;

internal sealed record BorrowedBookResponse
{
    /// <summary>
    /// The book id.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// The book title.
    /// </summary>
    [Required]
    public string Title { get; init; }
    
    /// <summary>
    /// The date by which the book should be returned.
    /// </summary>
    public DateOnly DueDate { get; init; }
}