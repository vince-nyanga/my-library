using MyLibrary.Query.Models;

namespace MyLibrary.Query;

public interface IBookQueryService
{
    ValueTask<IEnumerable<BookReadModel>> GetAllAsync();
}