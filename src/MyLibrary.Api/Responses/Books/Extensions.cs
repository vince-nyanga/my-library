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
}