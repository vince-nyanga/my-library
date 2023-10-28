using MyLibrary.Query.Models;

namespace MyLibrary.Query.Customers.Dtos;

internal static class Extensions
{
    public static CustomerSummary ToCustomerSummary(this CustomerReadModel customer)
    {
        if (customer is null)
        {
            return null;
        }
        
        return new()
        {
            Id = customer.Id,
            Name = customer.Name,
            EmailAddress = customer.EmailAddress,
            TotalUnreadNotifications = (ushort)customer.Notifications.Count
        };
    }

    public static Notification ToNotification(this NotificationReadModel notification)
    {
        return new()
        {
            Id = notification.Id,
            Message = notification.Message,
            SentDate = notification.SentDate
        };
    }
}