using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.Requests.Books;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Commands.Books;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Books;

[ApiController]
[Route("api/books")]
internal sealed class BorrowBookController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public BorrowBookController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    /// <summary>
    /// Borrows a book for the logged in user.
    /// </summary>
    /// <param name="id">The book ID</param>
    /// <param name="request">The request.</param>
    /// <remarks>
    ///
    /// Sample request
    ///
    ///     POST
    ///     {
    ///         "returnDate": "2023-12-25"
    ///     }
    /// </remarks>
    [HttpPost("{id:guid}/borrow", Name = nameof(BorrowBookAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Tags = new[] { "Books" })]
    public async Task<IActionResult> BorrowBookAsync(Guid id, [FromBody] BorrowBookRequest request)
    {
        await _commandDispatcher.SendAsync(new BorrowBook(id, request.ReturnDate));
        return Ok();
    }
}