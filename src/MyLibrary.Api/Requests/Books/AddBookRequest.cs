using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Requests.Books;

public sealed record AddBookRequest
{
    /// <summary>
    /// Required: The book ID.
    /// </summary>
    [Required]
    public Guid Id { get; init; }

    /// <summary>
    /// Required: The book title.
    /// </summary>
    [Required]
    public string Title { get; init; }
    
    /// <summary>
    /// The total copies available. Should be between 1 and 1000.
    /// </summary>
    [Range(1, 1000)]
    public ushort TotalCopies { get; init; }
}