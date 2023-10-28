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
}