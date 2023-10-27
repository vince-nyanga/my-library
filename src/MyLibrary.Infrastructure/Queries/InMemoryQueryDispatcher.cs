using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Infrastructure.Exceptions;
using MyLibrary.Query.Abstractions;

namespace MyLibrary.Infrastructure.Queries;

/// <summary>
/// Using in-memory for simplicity...
/// </summary>
internal sealed class InMemoryQueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async ValueTask<TQueryResult> DispatchAsync<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery<TQueryResult>
    {
        using var serviceScope = _serviceProvider.CreateScope();
        var queryHandler = serviceScope.ServiceProvider.GetService<IQueryHandler<TQuery, TQueryResult>>();

        if (queryHandler is null)
        {
            throw new QueryHandlerNotDefinedException(typeof(TQuery));
        }

        return await queryHandler.HandleAsync(query);
    }
}