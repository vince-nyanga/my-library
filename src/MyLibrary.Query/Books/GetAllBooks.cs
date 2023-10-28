using System.Collections.Immutable;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Books.Dtos;

namespace MyLibrary.Query.Books;

public record GetAllBooks : IQuery<IReadOnlyCollection<BookSummary>>;

internal sealed class GetAllBooksHandler : IQueryHandler<GetAllBooks, IReadOnlyCollection<BookSummary>>
{
    private readonly IBookQueryService _queryService;

    public GetAllBooksHandler(IBookQueryService queryService)
    {
        _queryService = queryService;
    }

    public async ValueTask<IReadOnlyCollection<BookSummary>> HandleAsync(GetAllBooks query)
    {
        var books = await _queryService.GetAllAsync();
        return books.Select(b => b.ToBookSummary()).ToImmutableArray();
    }
}