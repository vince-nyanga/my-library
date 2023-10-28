using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Application.Exceptions;

public sealed class ConflictingStateException : MyLibraryException
{
    public ConflictingStateException(string message)
        : base(message)
    {
    }
}