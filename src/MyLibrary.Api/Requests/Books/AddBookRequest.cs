using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Requests.Books;

internal sealed record AddBookRequest
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
    /// The number of copies. Should be between 1 and 1000.
    /// </summary>
    [Range(1, 1000)]
    public ushort NumberOfCopies { get; init; }
}