using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Responses.Notifications;

internal sealed record NotificationResponse
{
    /// <summary>
    /// The notification ID
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// The notification message
    /// </summary>
    [Required] 
    public string Message { get; init; }

    /// <summary>
    /// The date and time the notification was sent.
    /// </summary>
    public DateTimeOffset SentDate { get; init; }
}