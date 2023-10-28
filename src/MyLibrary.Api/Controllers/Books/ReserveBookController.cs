using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Commands.Books;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Books;

[ApiController]
[Route("api/books")]
internal sealed class ReserveBookController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public ReserveBookController(ICommandDispatcher commandDispatcher)
        => _commandDispatcher = commandDispatcher;

    /// <summary>
    /// Reserves a book for the logged in user.
    /// </summary>
    /// <param name="id">The book ID</param>
    [HttpPost("{id:guid}/reserve", Name = nameof(ReserveBookAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Tags = new[] { "Books" })]
    public async Task<IActionResult> ReserveBookAsync(Guid id)
    {
        await _commandDispatcher.SendAsync(new ReserveBook(id));
        return Ok();
    }
}