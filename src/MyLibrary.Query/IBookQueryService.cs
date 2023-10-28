using MyLibrary.Query.Models;

namespace MyLibrary.Query;

internal interface IBookQueryService
{
    ValueTask<IReadOnlyCollection<BookReadModel>> GetAllAsync();
    ValueTask<IReadOnlyCollection<BookReadModel>> SearchByTitleAsync(string searchTerm);
    ValueTask<IReadOnlyCollection<BorrowedBookCopyReadModel>> GetBorrowedBooksForCustomerAsync(string customerId);
    ValueTask<IReadOnlyCollection<ReservedBookCopyReadModel>> GetReservedBooksForCustomerAsync(string customerId);
}