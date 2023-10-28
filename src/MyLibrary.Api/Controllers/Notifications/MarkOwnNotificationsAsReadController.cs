using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Commands.Customers;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Notifications;

[ApiController]
[Route("api/notifications")]
internal sealed class MarkOwnNotificationsAsReadController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public MarkOwnNotificationsAsReadController(ICommandDispatcher commandDispatcher)
        => _commandDispatcher = commandDispatcher;

    /// <summary>
    /// Marks all of the logged in users' notifications as read.
    /// </summary>
    [HttpPost("own/mark-as-read", Name = nameof(MarkOwnNotificationsAsReadAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [SwaggerOperation(Tags = new[] { "Notifications" })]
    public async Task<IActionResult> MarkOwnNotificationsAsReadAsync()
    {
        await _commandDispatcher.SendAsync(new MarkAllNotificationsAsRead());
        return Ok();
    }
}