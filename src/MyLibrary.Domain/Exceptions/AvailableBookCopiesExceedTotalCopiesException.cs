using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class AvailableBookCopiesExceedTotalCopiesException : MyLibraryException
{
    public AvailableBookCopiesExceedTotalCopiesException(Guid bookId)
        : base($"Available copies for book {bookId} now exceed the total copies for the book available in the library")
    {
    }
}