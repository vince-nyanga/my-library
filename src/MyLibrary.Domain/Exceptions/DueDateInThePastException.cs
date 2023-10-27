using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Exceptions;

public sealed class DueDateInThePastException : MyLibraryException
{
    public DueDateInThePastException(DateOnly date)
        : base($"Date {date} cannot be in the past")
    {
    }
}