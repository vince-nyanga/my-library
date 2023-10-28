using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.Requests.Books;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Commands.Books;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Books;

[ApiController]
[Route("api/books")]
internal sealed class AddBookController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public AddBookController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    /// <summary>
    /// Adds a new book to the library.
    /// </summary>
    /// <param name="request">The request containing new book details.</param>
    /// <remarks>
    ///
    /// Sample request
    ///
    ///     POST
    ///     {
    ///         "id": "9D38EB55-BA24-4A88-AE50-EC19D08F2663",
    ///         "title": "My Wonderful BookReadModel",
    ///         "numberOfCopies": 4
    ///     }
    /// </remarks>
    [HttpPost(Name = nameof(AddBookAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [SwaggerOperation(Tags = new[] { "Books" })]
    public async Task<IActionResult> AddBookAsync([FromBody] AddBookRequest request)
    {
        await _commandDispatcher.SendAsync(new AddBook(request.Id, request.Title, request.NumberOfCopies));

        return Ok();
    }
}