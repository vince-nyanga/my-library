using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

public sealed record BookReservationId
{
    public BookReservationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyBookReservationIdException();
        }
        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(BookReservationId bookReservationId)
        => bookReservationId.Value;

    public static implicit operator BookReservationId(Guid value)
        => new(value);
}