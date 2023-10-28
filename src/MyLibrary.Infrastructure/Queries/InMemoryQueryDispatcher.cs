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
        => _serviceProvider = serviceProvider;

    public async ValueTask<TQueryResult> DispatchAsync<TQueryResult>(IQuery<TQueryResult> query)
    {
        using var serviceScope = _serviceProvider.CreateScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TQueryResult));
        var queryHandler = serviceScope.ServiceProvider.GetRequiredService(handlerType);

        if (queryHandler is null)
        {
            throw new QueryHandlerNotDefinedException(query.GetType());
        }

        return await (ValueTask<TQueryResult>) handlerType.GetMethod(nameof(IQueryHandler<IQuery<TQueryResult>, TQueryResult>.HandleAsync))?
            .Invoke(queryHandler, new[] {query});
    }
}