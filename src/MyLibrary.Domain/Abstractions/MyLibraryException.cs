namespace MyLibrary.Domain.Abstractions;

public abstract class MyLibraryException : Exception
{
    protected MyLibraryException(string message)
        : base(message)
    {
    }
}