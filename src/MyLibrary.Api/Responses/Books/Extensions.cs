using MyLibrary.Query.Books.Dtos;

namespace MyLibrary.Api.Responses.Books;

internal static class Extensions
{
    public static BookResponse ToBookResponse(this BookSummary summary)
    {
        return new()
        {
            Id = summary.Id,
            Title = summary.Title,
            AvailableCopies = summary.AvailableCopies,
            NextAvailableCopyDate = summary.NextAvailableCopyDate
        };
    }

    public static ReservedBookResponse ToReservedBookResponse(this ReservedBook reservedBook)
    {
        return new()
        {
            Id = reservedBook.Id,
            Title = reservedBook.Title,
            ReservationExpiryDate = reservedBook.ExpiryDate
        };
    }

    public static BorrowedBookResponse ToBorrowedBookResponse(this BorrowedBook borrowedBook)
    {
        return new()
        {
            Id = borrowedBook.Id,
            Title = borrowedBook.Title,
            DueDate = borrowedBook.DueDate
        };
    }
}