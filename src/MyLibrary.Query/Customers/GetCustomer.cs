using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Customers.Dtos;

namespace MyLibrary.Query.Customers;

public sealed record GetCustomer(string Id) : IQuery<CustomerSummary>;

internal sealed class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerSummary>
{
    private readonly ICustomerQueryService _customerQuery;
    private readonly IBookQueryService _bookQuery;

    public GetCustomerHandler(ICustomerQueryService customerQuery, IBookQueryService bookQuery)
    {
        _customerQuery = customerQuery;
        _bookQuery = bookQuery;
    }

    public async ValueTask<CustomerSummary> HandleAsync(GetCustomer query)
    {
        var customer = await _customerQuery.GetByIdAsync(query.Id);

        if (customer is null)
        {
            return null;
        }
        
        var reservedBooks = await _bookQuery.GetReservedBooksForCustomerAsync(query.Id);
        var borrowedBooks = await _bookQuery.GetBorrowedBooksForCustomerAsync(query.Id);
        return customer.ToCustomerSummary() with
        {
            TotalBorrowedBooks = (ushort)borrowedBooks.Count,
            TotalReservedBooks = (ushort)reservedBooks.Count
        };
    }
}