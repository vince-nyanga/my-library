using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Requests.Customers;

internal sealed record UpdateProfileRequest
{
    /// <summary>
    /// The first and last name.
    /// </summary>
    [Required]
    public string FullName { get; init; }

    /// <summary>
    /// The email address.
    /// </summary>
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }
}