using System.Collections.Immutable;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Books.Dtos;

namespace MyLibrary.Query.Books;

public record GetReservedBookForCustomer(string CustomerId) : IQuery<IReadOnlyCollection<ReservedBook>>;

internal sealed class GetReservedBookForCustomerHandler 
    : IQueryHandler<GetReservedBookForCustomer, IReadOnlyCollection<ReservedBook>>
{
    private readonly IBookQueryService _bookQuery;

    public GetReservedBookForCustomerHandler(IBookQueryService bookQuery)
        => _bookQuery = bookQuery;

    public async ValueTask<IReadOnlyCollection<ReservedBook>> HandleAsync(GetReservedBookForCustomer query)
    {
        var reservedBooks = await _bookQuery.GetReservedBooksForCustomerAsync(query.CustomerId);
        return reservedBooks.Select(b => b.ToReservedBook())
            .ToImmutableArray();
    }
}