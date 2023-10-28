using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.Responses;
using MyLibrary.Api.Responses.Books;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Books;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Books;

[ApiController]
[Route("api/books")]
internal sealed class GetAllBooksController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;

    public GetAllBooksController(IQueryDispatcher queryDispatcher)
        => _queryDispatcher = queryDispatcher;

    /// <summary>
    /// Gets all books in the library.
    /// </summary>
    [HttpGet(Name = nameof(GetAllBooksAsync))]
    [ProducesResponseType(typeof(IReadOnlyCollection<BookResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [SwaggerOperation(Tags = new[] { "Books" })]
    public async Task<IActionResult> GetAllBooksAsync()
    {
        var books = await _queryDispatcher.DispatchAsync(new GetAllBooks());

        return Ok(books.Select(b => b.ToBookResponse()));
    }
}