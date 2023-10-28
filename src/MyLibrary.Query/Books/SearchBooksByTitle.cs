using System.Collections.Immutable;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Books.Dtos;

namespace MyLibrary.Query.Books;

public sealed record SearchBooksByTitle(string SearchTerm) : IQuery<IReadOnlyCollection<BookSummary>>;

internal sealed class SearchBooksByTitleHandler : IQueryHandler<SearchBooksByTitle, IReadOnlyCollection<BookSummary>>
{
    private readonly IBookQueryService _queryService;

    public SearchBooksByTitleHandler(IBookQueryService queryService)
    {
        _queryService = queryService;
    }
    
    public async ValueTask<IReadOnlyCollection<BookSummary>> HandleAsync(SearchBooksByTitle query)
    {
        var books = await _queryService.SearchByTitleAsync(query.SearchTerm);
        return books.Select(b => b.ToBookSummary()).ToImmutableArray();
    }
}
