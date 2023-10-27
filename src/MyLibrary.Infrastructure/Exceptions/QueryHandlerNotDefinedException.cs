using System.Reflection;
using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Infrastructure.Exceptions;

public sealed class QueryHandlerNotDefinedException : MyLibraryException
{
    public QueryHandlerNotDefinedException(MemberInfo type) 
        : base($"There is no handler defined for type '{type.Name}'")
    {
    }
}