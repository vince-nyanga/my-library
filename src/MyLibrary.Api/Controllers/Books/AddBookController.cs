using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.Requests.Books;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Commands.Books;

namespace MyLibrary.Api.Controllers.Books;

[ApiController]
[Route("api/books")]
public class AddBookController : ControllerBase
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
    [HttpPost(Name = nameof(AddBookAsync))]
    public async Task<IActionResult> AddBookAsync([FromBody] AddBookRequest request)
    {
        await _commandDispatcher.SendAsync(new AddBook(request.Id, request.Title, request.TotalCopies));

        return Ok();
    }
}