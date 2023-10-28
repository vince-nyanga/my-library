using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class InvalidEmailAddressException : MyLibraryException
{
    public InvalidEmailAddressException(string value)
        : base($"'{value}' is an invalid email address")
    {
    }
}