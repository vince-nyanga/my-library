using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Application.Exceptions;

public sealed class EntityNotFoundException : MyLibraryException
{
    public EntityNotFoundException(string message)
        : base(message)
    {
    }
}