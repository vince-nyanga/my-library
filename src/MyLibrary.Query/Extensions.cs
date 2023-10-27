using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Query.Abstractions;

namespace MyLibrary.Query;

public static class Extensions
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblyOf<IQueryDispatcher>()
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}