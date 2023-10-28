using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

internal sealed class EmptyCustomerIdException : MyLibraryException
{
    public EmptyCustomerIdException()
        : base("Customer ID cannot be empty")
    {
    }
}