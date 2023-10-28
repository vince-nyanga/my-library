using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.Responses.Books;
using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Books;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Books;

[ApiController]
[Route("api/books")]
internal sealed class GetOwnBorrowedBooksController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IUserContextProvider _userContextProvider;

    public GetOwnBorrowedBooksController(IQueryDispatcher queryDispatcher, IUserContextProvider userContextProvider)
    {
        _queryDispatcher = queryDispatcher;
        _userContextProvider = userContextProvider;
    }

    /// <summary>
    /// Gets a list of the logged in user's borrowed books
    /// </summary>
    /// <returns></returns>
    [HttpGet("own/borrowed", Name = nameof(GetOwnBorrowedBooksAsync))]
    [ProducesResponseType(typeof(IReadOnlyCollection<BorrowedBookResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [SwaggerOperation(Tags = new[] { "Books" })]
    public async Task<IActionResult> GetOwnBorrowedBooksAsync()
    {
        var books = await _queryDispatcher.DispatchAsync(new GetBorrowedBooksForCustomer(_userContextProvider.UserId));
        return Ok(books.Select(b => b.ToBorrowedBookResponse()));
    }
}