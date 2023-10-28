using System.Collections.Immutable;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Books.Dtos;

namespace MyLibrary.Query.Books;

public record GetBorrowedBooksForCustomer(string CustomerId) : IQuery<IReadOnlyCollection<BorrowedBook>>;

internal sealed class GetBorrowedBooksForCustomerHandler 
    : IQueryHandler<GetBorrowedBooksForCustomer, IReadOnlyCollection<BorrowedBook>>
{
    private readonly IBookQueryService _bookQuery;

    public GetBorrowedBooksForCustomerHandler(IBookQueryService bookQuery)
        => _bookQuery = bookQuery;

    public async ValueTask<IReadOnlyCollection<BorrowedBook>> HandleAsync(GetBorrowedBooksForCustomer query)
    {
        var borrowedBooks = await _bookQuery.GetBorrowedBooksForCustomerAsync(query.CustomerId);
        return borrowedBooks.Select(b => b.ToBorrowedBook())
            .ToImmutableArray();
    }
}