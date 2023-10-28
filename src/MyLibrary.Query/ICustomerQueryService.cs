using MyLibrary.Query.Models;

namespace MyLibrary.Query;

internal interface ICustomerQueryService
{
    ValueTask<CustomerReadModel> GetByIdAsync(string id);
}