using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Commands.Books;

namespace MyLibrary.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblyOf<AddBookHandler>()
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}