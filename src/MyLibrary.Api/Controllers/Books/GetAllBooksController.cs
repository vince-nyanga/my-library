using Microsoft.AspNetCore.Mvc;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Books;
using MyLibrary.Query.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Books;

[ApiController]
[Route("api/books")]
internal sealed class GetAllBooksController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;

    public GetAllBooksController(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    /// <summary>
    /// Gets all books in the library.
    /// </summary>
    [HttpGet(Name = nameof(GetAllBooksAsync))]
    [ProducesResponseType(typeof(BookReadModel), StatusCodes.Status200OK)]
    [SwaggerOperation(Tags = new[] { "Books" })]
    public async Task<IActionResult> GetAllBooksAsync()
    {
        var books = await _queryDispatcher.DispatchAsync(new GetAllBooks());

        return Ok(books);
    }
}