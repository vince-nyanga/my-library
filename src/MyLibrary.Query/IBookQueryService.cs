using MyLibrary.Query.Models;

namespace MyLibrary.Query;

internal interface IBookQueryService
{
    ValueTask<IReadOnlyCollection<BookReadModel>> GetAllAsync();
}