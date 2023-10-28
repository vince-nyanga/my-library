using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Responses.Books;

internal sealed record ReservedBookResponse
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
    /// The date and time on which the reservation will expire.
    /// </summary>
    public DateTime ReservationExpiryDate { get; init; }
}