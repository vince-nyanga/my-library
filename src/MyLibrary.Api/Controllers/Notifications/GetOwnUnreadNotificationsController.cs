using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.Responses.Notifications;
using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Customers;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLibrary.Api.Controllers.Notifications;

[ApiController]
[Route("api/notifications")]
internal sealed class GetOwnUnreadNotificationsController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IUserContextProvider _userContextProvider;

    public GetOwnUnreadNotificationsController(IQueryDispatcher queryDispatcher, IUserContextProvider userContextProvider)
    {
        _queryDispatcher = queryDispatcher;
        _userContextProvider = userContextProvider;
    }

    /// <summary>
    /// Gets unread notifications for the logged in user.
    /// </summary>
    /// <returns></returns>
    [HttpGet("own/unread", Name = nameof(GetOwnUnreadNotificationsAsync))]
    [ProducesResponseType(typeof(IReadOnlyCollection<NotificationResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [SwaggerOperation(Tags = new[] { "Notifications" })]
    public async Task<IActionResult> GetOwnUnreadNotificationsAsync()
    {
        var notifications =
            await _queryDispatcher.DispatchAsync(new GetUnreadNotificationsForCustomer(_userContextProvider.UserId));

        return Ok(notifications.Select(n => n.ToNotificationResponse()));
    }
}