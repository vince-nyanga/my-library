using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

internal sealed record CustomerName
{
    public CustomerName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyCustomerNameException();
        }
        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(CustomerName customerName)
        => customerName.Value;

    public static implicit operator CustomerName(string value)
        => new(value);
}