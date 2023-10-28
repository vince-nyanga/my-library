using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Application;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Abstractions.Repositories;
using MyLibrary.Infrastructure.Commands;
using MyLibrary.Infrastructure.EntityFramework.Contexts;
using MyLibrary.Infrastructure.Queries;
using MyLibrary.Infrastructure.Repositories;
using MyLibrary.Query;
using MyLibrary.Query.Abstractions;

namespace MyLibrary.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<WriteDbContext>(options => options.UseNpgsql(connectionString))
            .AddDbContext<ReadDbContext>(options => options.UseNpgsql(connectionString))
            .AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>()
            .AddApplication()
            .AddScoped<IBookRepository, SqlBookRepository>()
            .AddScoped<ICustomerRepository, SqlCustomerRepository>()
            .AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>()
            .AddScoped<IBookQueryService, SqlBookQueryService>()
            .AddQueries();

        EnsureDatabaseCreated(services);
        return services;
    }

    /// <summary>
    /// WARNING: Do not do this in a production application. Use migrations instead.
    /// </summary>
    /// <remarks>I just decided to take a shortcut 😜.</remarks>
    private static void EnsureDatabaseCreated(IServiceCollection services)
    {
        using var serviceScope = services.BuildServiceProvider().CreateScope();
        var ctx = serviceScope.ServiceProvider.GetRequiredService<WriteDbContext>();
        ctx.Database.EnsureCreated();
    }
}