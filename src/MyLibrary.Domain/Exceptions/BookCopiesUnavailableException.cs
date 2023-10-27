using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Exceptions;

public sealed class BookCopiesUnavailableException : MyLibraryException
{
    public BookCopiesUnavailableException(Guid bookId)
        : base($"There a no available copies for book {bookId}")
    {
    }
}