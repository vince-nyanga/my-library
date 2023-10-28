using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Application.Exceptions;

public sealed class ValidationException : MyLibraryException
{
    public ValidationException(string message)
        : base(message)
    {
    }
}