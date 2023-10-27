using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

public sealed record BookTitle
{
    public BookTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyBookTitleException();
        }
        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(BookTitle bookTitle)
        => bookTitle.Value;

    public static implicit operator BookTitle(string value)
        => new(value);
}