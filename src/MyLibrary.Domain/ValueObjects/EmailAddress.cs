using System.Text.RegularExpressions;
using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Domain.ValueObjects;

public sealed record EmailAddress
{
    // naive email address regex pattern. Not for use in production.
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    public EmailAddress(string value)
    {
        ValidateEmailAddress(value);
        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(EmailAddress emailAddress)
        => emailAddress.Value;

    public static implicit operator EmailAddress(string value)
        => new(value);

    private static void ValidateEmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyEmailAddressException();
        }

        if (!Regex.IsMatch(value, Pattern))
        {
            throw new InvalidEmailAddressException(value);
        }
    }
}