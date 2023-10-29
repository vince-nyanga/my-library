using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Responses.Books;

internal sealed record BorrowedBookResponse
{
    /// <summary>
    /// The book id.
    /// </summary>
    /// <example>EABAA778-F8F2-4491-B80D-F9B5B15A0237</example>
    public Guid Id { get; init; }
    
    /// <summary>
    /// The book title.
    /// </summary>
    /// <example>The Green Moon by John Doe</example>
    [Required]
    public string Title { get; init; }
    
    /// <summary>
    /// The date by which the book should be returned.
    /// </summary>
    /// <example>2023-12-25</example>
    public DateOnly DueDate { get; init; }
}