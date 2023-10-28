using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class BookStockNotBalancingException : MyLibraryException
{
    public BookStockNotBalancingException(Guid bookId, ushort expectedTotal, ushort actualTotal)
        : base($"Stock for book {bookId} does not balance. Expected total {expectedTotal}, actual total {actualTotal}")
    {
    }
}