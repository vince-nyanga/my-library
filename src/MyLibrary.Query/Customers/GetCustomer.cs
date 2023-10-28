using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Customers.Dtos;

namespace MyLibrary.Query.Customers;

public sealed record GetCustomer(string Id) : IQuery<CustomerSummary>;

internal sealed class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerSummary>
{
    private readonly ICustomerQueryService _queryService;

    public GetCustomerHandler(ICustomerQueryService queryService)
    {
        _queryService = queryService;
    }

    public async ValueTask<CustomerSummary> HandleAsync(GetCustomer query)
    {
        var customer = await _queryService.GetByIdAsync(query.Id);
        return customer.ToCustomerSummary();
    }
}