using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Requests.Books;

internal sealed record AddBookRequest
{
    /// <summary>
    /// Required: The book ID.
    /// </summary>
    /// <example>EABAA778-F8F2-4491-B80D-F9B5B15A0237</example>
    [Required]
    public Guid Id { get; init; }

    /// <summary>
    /// Required: The book title.
    /// </summary>
    /// <example>The Green Moon by John Doe</example>
    [Required]
    public string Title { get; init; }
    
    /// <summary>
    /// The number of copies. Should be between 1 and 1000.
    /// </summary>
    /// <example>18</example>
    [Range(1, 1000)]
    public ushort NumberOfCopies { get; init; }
}