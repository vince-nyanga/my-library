using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

public sealed record CustomerId
{
    public CustomerId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyCustomerIdException();
        }
        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(CustomerId customerId)
        => customerId.Value;

    public static implicit operator CustomerId(Guid value)
        => new(value);
}