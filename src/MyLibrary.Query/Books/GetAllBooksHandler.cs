using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Models;

namespace MyLibrary.Query.Books;

internal sealed class GetAllBooksHandler : IQueryHandler<GetAllBooks, IReadOnlyCollection<BookReadModel>>
{
    private readonly IBookQueryService _queryService;

    public GetAllBooksHandler(IBookQueryService queryService)
    {
        _queryService = queryService;
    }

    public async ValueTask<IReadOnlyCollection<BookReadModel>> HandleAsync(GetAllBooks query)
    {
        return await _queryService.GetAllAsync();
    }
}