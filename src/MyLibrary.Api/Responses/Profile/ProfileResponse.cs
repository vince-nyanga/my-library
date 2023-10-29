using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Responses.Profile;

internal sealed record ProfileResponse
{
    /// <summary>
    /// The user's full name.
    /// </summary>
    /// <example>John Doe</example>
    [Required]
    public string FullName { get; init; }
    
    /// <summary>
    /// The user's email address.
    /// </summary>
    /// <example>john@email.com</example>
    [Required]
    public string EmailAddress { get; init; }
    
    /// <summary>
    /// The user's total unread notifications
    /// </summary>
    /// <example>1</example>
    public ushort TotalUnreadNotifications { get; init; }

    /// <summary>
    /// The number of borrowed books the user has not returned yet.
    /// </summary>
    /// <example>1</example>
    public ushort TotalBorrowedBooks { get; init; }
    
    /// <summary>
    /// The number of books the user has reserved.
    /// </summary>
    /// <example>0</example>
    public ushort TotalReservedBooks { get; init; }
}