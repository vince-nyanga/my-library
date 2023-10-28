using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

internal sealed record BorrowedBookId
{
    public BorrowedBookId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyBorrowedBookIdException();
        }
        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(BorrowedBookId borrowedBookId)
        => borrowedBookId.Value;

    public static implicit operator BorrowedBookId(Guid value)
        => new(value);
}