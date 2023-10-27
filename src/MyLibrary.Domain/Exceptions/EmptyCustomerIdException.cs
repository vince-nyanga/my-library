using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class EmptyCustomerIdException : MyLibraryException
{
    public EmptyCustomerIdException()
        : base("Customer ID cannot be empty")
    {
    }
}