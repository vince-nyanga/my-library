using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class EmptyEmailAddressException : MyLibraryException
{
    public EmptyEmailAddressException()
        : base("Email address cannot be empty")
    {
    }
}