using MyLibrary.Query.Models;

namespace MyLibrary.Query.Books.Dtos;

internal static class Extensions
{
    public static BookSummary ToBookSummary(this BookReadModel book)
    {
        if (book is null)
        {
            return null;
        }
        
        return new()
        {
            Id = book.Id,
            Title = book.Title,
            AvailableCopies = book.AvailableCopies,
            TotalCopies = book.TotalCopies,
            NextAvailableCopyDate = book.BorrowedCopies.MinBy(c => c.DueDate)?.DueDate
        };
    }

    public static BorrowedBook ToBorrowedBook(this BorrowedBookCopyReadModel borrowedBook)
    {
        return new()
        {
            Id = borrowedBook.Id,
            Title = borrowedBook.Book.Title,
            DueDate = borrowedBook.DueDate,
            CustomerId = borrowedBook.CustomerId
        };
    }

    public static ReservedBook ToReservedBook(this ReservedBookCopyReadModel reservedReservedBook)
    {
        return new ReservedBook()
        {
            Id = reservedReservedBook.Id,
            Title = reservedReservedBook.Book.Title,
            CustomerId = reservedReservedBook.CustomerId,
            ExpiryDate = reservedReservedBook.DateReserved.AddHours(24) // TODO: this should be configurable
        };
    }
}