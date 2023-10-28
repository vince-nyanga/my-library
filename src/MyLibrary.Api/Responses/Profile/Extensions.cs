using MyLibrary.Query.Customers.Dtos;

namespace MyLibrary.Api.Responses.Profile;

internal static class Extensions
{
    public static ProfileResponse ToProfileResponse(this CustomerSummary customer)
    {
        return new()
        {
            FullName = customer.Name,
            EmailAddress = customer.EmailAddress,
            TotalUnreadNotifications = customer.TotalUnreadNotifications,
            TotalBorrowedBooks = customer.TotalBorrowedBooks,
            TotalReservedBooks = customer.TotalReservedBooks
        };
    }
}