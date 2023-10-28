using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Commands.Books;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Books;

[ApiController]
[Route("api/books")]
internal sealed class CancelReservationController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public CancelReservationController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    /// <summary>
    /// Cancels the logged in user's reservation.
    /// </summary>
    /// <param name="id">The book ID</param>
    [HttpPost("{id:guid}/cancel-reservation", Name = nameof(CancelReservationAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Tags = new[] { "Books" })]
    public async Task<IActionResult> CancelReservationAsync(Guid id)
    {
        await _commandDispatcher.SendAsync(new CancelReservation(id));
        return Ok();
    }
}