using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

public sealed record BookId
{
    public BookId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyBookIdException();
        }
        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(BookId bookId)
        => bookId.Value;

    public static implicit operator BookId(Guid value)
        => new(value);
}