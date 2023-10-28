using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.Requests.Books;
using MyLibrary.Api.Responses.Books;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Books;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Books;

[ApiController]
[Route("api/books")]
internal sealed class SearchBooksController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;

    public SearchBooksController(IQueryDispatcher queryDispatcher)
        => _queryDispatcher = queryDispatcher;

    /// <summary>
    /// Searches for books by title.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("search", Name = nameof(SearchBooksByTitleAsync))]
    [ProducesResponseType(typeof(IReadOnlyCollection<BookResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [SwaggerOperation(Tags = new[] { "Books" })]
    public async Task<IActionResult> SearchBooksByTitleAsync([FromBody] SearchBookByTitleRequest request)
    {
        var books = await _queryDispatcher.DispatchAsync(new SearchBooksByTitle(request.SearchTerm));
        return Ok(books.Select(b => b.ToBookResponse()));
    }
}