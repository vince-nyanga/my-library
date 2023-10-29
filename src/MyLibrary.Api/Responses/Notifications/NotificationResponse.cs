using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Responses.Notifications;

internal sealed record NotificationResponse
{
    /// <summary>
    /// The notification ID
    /// </summary>
    /// <example>4DAFDD3F-CBFE-4412-8690-15D25E771E13</example>
    public Guid Id { get; set; }
    
    /// <summary>
    /// The notification message
    /// </summary>
    /// <example>Your reservation for The Green Moon by John Doe has expired.</example>
    [Required] 
    public string Message { get; init; }

    /// <summary>
    /// The date and time the notification was sent.
    /// </summary>
    /// <example>2023-12-25T06:00:00.000Z</example>
    public DateTimeOffset SentDate { get; init; }
}