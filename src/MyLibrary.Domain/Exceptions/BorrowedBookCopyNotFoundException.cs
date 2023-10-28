using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class BorrowedBookCopyNotFoundException : MyLibraryException
{
    public BorrowedBookCopyNotFoundException(Guid bookId, Guid borrowedCopyId)
        : base($"Book {bookId} does not contain a borrowing with ID {borrowedCopyId}")
    {
    }
}