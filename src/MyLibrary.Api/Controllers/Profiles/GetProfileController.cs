using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.Responses.Profile;
using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Customers;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Profiles;

[ApiController]
[Route("api/profiles")]
internal sealed class GetProfileController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IUserContextProvider _userContextProvider;

    public GetProfileController(IQueryDispatcher queryDispatcher, IUserContextProvider userContextProvider)
    {
        _queryDispatcher = queryDispatcher;
        _userContextProvider = userContextProvider;
    }

    /// <summary>
    /// Gets the profile of the logged in user.
    /// </summary>
    /// <returns></returns>
    [HttpGet("own", Name = nameof(GetOwnProfileAsync))]
    [ProducesResponseType(typeof(ProfileResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [SwaggerOperation(Tags = new[] { "Customers" })]
    public async Task<IActionResult> GetOwnProfileAsync()
    {
        var customer = await _queryDispatcher.DispatchAsync(new GetCustomer(_userContextProvider.UserId));

        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer.ToProfileResponse());
    }
}