using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class CustomerAlreadyReservedOrBorrowedBookException : MyLibraryException
{
    public CustomerAlreadyReservedOrBorrowedBookException(Guid bookId, string customerId)
        : base($"Customer {customerId} has already borrowed or reserved a copy of book {bookId}")
    {
    }
}