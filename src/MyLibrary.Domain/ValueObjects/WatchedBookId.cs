using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

internal sealed record WatchedBookId
{
    public WatchedBookId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyBookIdException();
        }
        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(WatchedBookId bookId)
        => bookId.Value;

    public static implicit operator WatchedBookId(Guid value)
        => new(value);
}