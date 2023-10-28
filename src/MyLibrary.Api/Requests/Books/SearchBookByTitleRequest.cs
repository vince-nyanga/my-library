using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Requests.Books;

internal sealed record SearchBookByTitleRequest
{
    /// <summary>
    /// The search term.
    /// </summary>
    [Required]
    public string SearchTerm { get; init; }
}