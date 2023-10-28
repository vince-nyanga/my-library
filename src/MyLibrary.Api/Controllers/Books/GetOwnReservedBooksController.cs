using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.Responses.Books;
using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Books;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Books;

[ApiController]
[Route("api/books")]
internal sealed class GetOwnReservedBooksController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IUserContextProvider _userContextProvider;

    public GetOwnReservedBooksController(IQueryDispatcher queryDispatcher, IUserContextProvider userContextProvider)
    {
        _queryDispatcher = queryDispatcher;
        _userContextProvider = userContextProvider;
    }

    /// <summary>
    /// Gets a list of the logged in user's reserved books.
    /// </summary>
    /// <returns></returns>
    [HttpGet("own/reserved", Name = nameof(GetOwnReservedBooksAsync))]
    [ProducesResponseType(typeof(IReadOnlyCollection<ReservedBookResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [SwaggerOperation(Tags = new[] { "Books" })]
    public async Task<IActionResult> GetOwnReservedBooksAsync()
    {
        var books = await _queryDispatcher.DispatchAsync(new GetReservedBookForCustomer(_userContextProvider.UserId));
        return Ok(books.Select(b => b.ToReservedBookResponse()));
    }
}