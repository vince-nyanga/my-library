using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Abstractions.DomainEvents;
using MyLibrary.Application.Commands.Books;
using MyLibrary.Application.DomainEventHandlers;
using MyLibrary.Domain.Events;

namespace MyLibrary.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblyOf<AddBookHandler>()
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        services.Scan(s => s.FromAssemblyOf<BookCopyReturnedHandler>()
            .AddClasses(c => c.AssignableTo(typeof(IDomainEventHandler<>)), publicOnly: false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        return services;
    }
}