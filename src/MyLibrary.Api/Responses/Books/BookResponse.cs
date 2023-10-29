using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Responses.Books;

internal sealed record class BookResponse
{
    /// <summary>
    /// The book id.
    /// </summary>
    /// <example>EABAA778-F8F2-4491-B80D-F9B5B15A0237</example>
    [Required]
    public Guid Id { get; init; }
    
    /// <summary>
    /// The book title.
    /// </summary>
    /// <example>The Green Moon by John Doe</example>
    [Required]
    public string Title { get; init; }
    
    /// <summary>
    /// Total copies available in the library at the moment.
    /// </summary>
    /// <example>17</example>
    public ushort AvailableCopies { get; init; }
    
    /// <summary>
    /// The closest date when a borrowed copy will be returned.
    /// </summary>
    /// <example>2023-12-25</example>
    public DateOnly? NextAvailableCopyDate { get; init; }
}