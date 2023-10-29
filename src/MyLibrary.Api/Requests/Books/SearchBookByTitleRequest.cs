using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Requests.Books;

internal sealed record SearchBookByTitleRequest
{
    /// <summary>
    /// The search term.
    /// </summary>
    /// <example>The Green</example>
    [Required]
    public string SearchTerm { get; init; }
}