using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Requests.Customers;

internal sealed record UpdateProfileRequest
{
    /// <summary>
    /// The first and last name.
    /// </summary>
    /// <example>John Doe</example>
    [Required]
    public string FullName { get; init; }

    /// <summary>
    /// The email address.
    /// </summary>
    /// <example>john@email.com</example>
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }
}