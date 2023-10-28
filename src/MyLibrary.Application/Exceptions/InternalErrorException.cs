using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Application.Exceptions;

public sealed class InternalErrorException : MyLibraryException
{
    public InternalErrorException()
        : base("Something went wrong on our side")
    {
    }
}