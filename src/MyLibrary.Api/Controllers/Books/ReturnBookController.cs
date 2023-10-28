using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Commands.Books;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Books;

[ApiController]
[Route("api/books")]
internal sealed class ReturnBookController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public ReturnBookController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    /// <summary>
    /// Returns a book to the library
    /// </summary>
    /// <param name="id">The book ID</param>
    [HttpPost("{id:guid}/return", Name = nameof(ReturnBookAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Tags = new[] { "Books" })]
    public async Task<IActionResult> ReturnBookAsync(Guid id)
    {
        await _commandDispatcher.SendAsync(new ReturnBook(id));
        return Ok();
    }
}