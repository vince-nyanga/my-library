using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Books;

namespace MyLibrary.Query;

public static class Extensions
{
    internal static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblyOf<GetAllBooks>()
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}