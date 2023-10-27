using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

public sealed record CustomerId
{
    public CustomerId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyCustomerIdException();
        }
        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(CustomerId customerId)
        => customerId.Value;

    public static implicit operator CustomerId(string value)
        => new(value);
}