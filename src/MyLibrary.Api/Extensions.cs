using System.Reflection;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using MyLibrary.Api.Auth;
using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Application.Exceptions;
using Swashbuckle.AspNetCore.SwaggerGen;
using ProblemDetailsOptions = Hellang.Middleware.ProblemDetails.ProblemDetailsOptions;

namespace MyLibrary.Api;

internal static class Extensions
{
    public static IServiceCollection AddProblemDetailsConfiguration(this IServiceCollection services)
    {
        services.AddProblemDetails(ConfigureProblemDetails);
        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor()
            .AddScoped<IUserContextProvider, HttpUserContextProvider>()
            .AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = configuration["Authentication:Domain"];
                options.Audience = configuration["Authentication:Audience"];
            });

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My Library API",
                Version = "v1",
                Description = "REST API for My Library"
            });

            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        Scopes = new Dictionary<string, string>
                        {
                            { "openid", "Open Id" }
                        },
                        AuthorizationUrl = new Uri(configuration["Authentication:Domain"] + "authorize?audience=" +
                                                   configuration["Authentication:Audience"])
                    }
                }
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"
                        }
                    },
                    new[] { "openid" }
                }
            });

            options.IncludeXmlCommentsIfExists();
        });

        return services;
    }

    private static void ConfigureProblemDetails(ProblemDetailsOptions options)
    {
        options.IncludeExceptionDetails = (_, _) => false;
        options.MapToStatusCode<ForbiddenActionException>(StatusCodes.Status403Forbidden);
    }

    private static void IncludeXmlCommentsIfExists(this SwaggerGenOptions options)
    {
        var path = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, ".xml");
        if (File.Exists(path))
        {
            options.IncludeXmlComments(path);
        }
    }
}