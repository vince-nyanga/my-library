using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Responses.Books;

internal sealed record ReservedBookResponse
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
    /// The date and time on which the reservation will expire.
    /// </summary>
    /// <example>2023-12-25T06:00:00.000Z</example>
    public DateTimeOffset ReservationExpiryDate { get; init; }
}