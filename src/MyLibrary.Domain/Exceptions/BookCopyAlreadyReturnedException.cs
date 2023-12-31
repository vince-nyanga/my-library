using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class BookCopyAlreadyReturnedException : MyLibraryException
{
    public BookCopyAlreadyReturnedException(Guid borrowedCopyId, Guid bookId)
        : base($"Borrowed copy {borrowedCopyId} for book {bookId} is already returned")
    {
    }
}