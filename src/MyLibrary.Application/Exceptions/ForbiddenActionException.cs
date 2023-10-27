using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Application.Exceptions;

public sealed class ForbiddenActionException : MyLibraryException
{
    public ForbiddenActionException(string message) : base(message)
    {
    }
}