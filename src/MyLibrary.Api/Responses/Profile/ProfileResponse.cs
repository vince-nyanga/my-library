using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Responses.Profile;

internal sealed record ProfileResponse
{
    /// <summary>
    /// The user's full name.
    /// </summary>
    [Required]
    public string FullName { get; init; }
    
    /// <summary>
    /// The user's email address.
    /// </summary>
    [Required]
    public string EmailAddress { get; init; }
    
    /// <summary>
    /// The user's total unread notifications
    /// </summary>
    public ushort TotalUnreadNotifications { get; init; }

    /// <summary>
    /// The number of borrowed books the user has not returned yet.
    /// </summary>
    public ushort TotalBorrowedBooks { get; init; }
    
    /// <summary>
    /// The number of books the user has reserved.
    /// </summary>
    public ushort TotalReservedBooks { get; init; }
}