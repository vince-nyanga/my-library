using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class InvalidEmailAddressException : MyLibraryException
{
    public InvalidEmailAddressException(string value)
        : base($"'{value}' is an invalid email address")
    {
        Value = value;
    }

    public string Value { get; }
}