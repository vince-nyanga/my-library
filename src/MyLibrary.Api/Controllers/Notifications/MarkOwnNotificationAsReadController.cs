using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Commands.Customers;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Notifications;

[ApiController]
[Route("api/notifications")]
internal sealed class MarkOwnNotificationAsReadController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public MarkOwnNotificationAsReadController(ICommandDispatcher commandDispatcher)
        => _commandDispatcher = commandDispatcher;

    /// <summary>
    /// Marks a notification as read.
    /// </summary>
    /// <param name="id">The notification ID.</param>
    [HttpPost("own/{id:guid}/mark-as-read", Name = nameof(MarkOwnNotificationAsReadAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [SwaggerOperation(Tags = new[] { "Notifications" })]
    public async Task<IActionResult> MarkOwnNotificationAsReadAsync(Guid id)
    {
        await _commandDispatcher.SendAsync(new MarkNotificationAsRead(id));
        return Ok();
    }
}