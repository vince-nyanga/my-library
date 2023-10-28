using System.Collections.Immutable;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Customers.Dtos;

namespace MyLibrary.Query.Customers;

public sealed record GetUnreadNotificationsForCustomer(string CustomerId) : IQuery<IReadOnlyCollection<Notification>>;

internal sealed class GetUnreadNotificationsForCustomerHandler
    : IQueryHandler<GetUnreadNotificationsForCustomer, IReadOnlyCollection<Notification>>
{
    private readonly ICustomerQueryService _queryService;

    public GetUnreadNotificationsForCustomerHandler(ICustomerQueryService queryService)
        => _queryService = queryService;

    public async ValueTask<IReadOnlyCollection<Notification>> HandleAsync(GetUnreadNotificationsForCustomer query)
    {
        var customer = await _queryService.GetByIdAsync(query.CustomerId);
        if (customer is null)
        {
            return Array.Empty<Notification>();
        }

        return customer.Notifications.Select(n => n.ToNotification())
            .ToImmutableArray();
    }
}