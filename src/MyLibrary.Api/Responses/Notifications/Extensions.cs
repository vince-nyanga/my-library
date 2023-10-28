using MyLibrary.Query.Customers.Dtos;

namespace MyLibrary.Api.Responses.Notifications;

internal static class Extensions
{
    public static NotificationResponse ToNotificationResponse(this Notification notification)
    {
        return new()
        {
            Id = notification.Id,
            Message = notification.Message,
            SentDate = notification.SentDate
        };
    }
}