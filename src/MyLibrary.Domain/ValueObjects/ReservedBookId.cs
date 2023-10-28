using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

public sealed record ReservedBookId
{
    public ReservedBookId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyBookReservationIdException();
        }
        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(ReservedBookId reservedBookId)
        => reservedBookId.Value;

    public static implicit operator ReservedBookId(Guid value)
        => new(value);
}