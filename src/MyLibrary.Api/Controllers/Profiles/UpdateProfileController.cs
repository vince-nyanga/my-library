using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.Requests.Customers;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Commands.Customers;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Profiles;

[ApiController]
[Route("api/profile")]
internal sealed class UpdateProfileController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public UpdateProfileController(ICommandDispatcher commandDispatcher)
        => _commandDispatcher = commandDispatcher;

    /// <summary>
    /// Updates the logged in user's profile.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <remarks>
    /// 
    /// Sample request:
    ///
    ///     POST
    ///     {
    ///         "fullName": "John Doe",
    ///         "emailAddress": "john@honesdev.com"
    ///     }
    /// </remarks>
    [HttpPost(Name = nameof(UpdateProfileAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [SwaggerOperation(Tags = new[] { "Customers" })]
    public async Task<IActionResult> UpdateProfileAsync([FromBody] UpdateProfileRequest request)
    {
        var command = new UpdateCustomerProfile(request.FullName, request.EmailAddress);
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
}