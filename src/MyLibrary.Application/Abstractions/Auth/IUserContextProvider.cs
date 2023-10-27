using System.Security.Claims;

namespace MyLibrary.Application.Abstractions.Auth;

public interface IUserContextProvider
{
    string UserId { get; }
    IReadOnlyCollection<string> Permissions { get; }
}