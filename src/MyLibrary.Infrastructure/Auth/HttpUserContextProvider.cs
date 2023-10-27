using System.Collections.Immutable;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MyLibrary.Application.Abstractions.Auth;

namespace MyLibrary.Infrastructure.Auth;

internal sealed class HttpUserContextProvider : IUserContextProvider
{
    private const string PermissionsClaimType = "permissions";
    
    public HttpUserContextProvider(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext!.User;
        UserId = user.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        Permissions = user.Claims.Where(c => c.Type == PermissionsClaimType)
            .Select(c => c.Value).ToImmutableArray();
    }
    
    public string UserId { get; }
    public IReadOnlyCollection<string> Permissions { get; }
}