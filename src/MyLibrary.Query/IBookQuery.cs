using MyLibrary.Query.Models;

namespace MyLibrary.Query;

public interface IBookQuery
{
    ValueTask<IEnumerable<BookReadModel>> GetAllAsync();
}