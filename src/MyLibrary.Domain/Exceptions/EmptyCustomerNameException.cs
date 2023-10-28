using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class EmptyCustomerNameException : MyLibraryException
{
    public EmptyCustomerNameException()
        : base("Customer name cannot be null or empty")
    {
    }
}