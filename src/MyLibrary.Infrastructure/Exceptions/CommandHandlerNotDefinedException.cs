using System.Reflection;
using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Infrastructure.Exceptions;

public sealed class CommandHandlerNotDefinedException : MyLibraryException
{
    public CommandHandlerNotDefinedException(MemberInfo type) 
        : base($"There is no handler defined for type '{type.Name}'")
    {
    }
}