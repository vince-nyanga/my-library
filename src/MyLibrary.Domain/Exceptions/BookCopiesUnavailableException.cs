using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class BookCopiesUnavailableException : MyLibraryException
{
    public BookCopiesUnavailableException(Guid bookId)
        : base($"There a no available copies for book {bookId}")
    {
    }
}