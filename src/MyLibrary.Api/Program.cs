using Hellang.Middleware.ProblemDetails;
using MyLibrary.Api;
using MyLibrary.Api.BackgroundServices;
using MyLibrary.Api.Features;
using MyLibrary.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<NotificationBrokerService>();
builder.Services.AddControllers()
    .ConfigureApplicationPartManager(manager =>
    {
        manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
    });

builder.Services.AddInfrastructure(builder.Configuration)
    .AddProblemDetailsConfiguration()
    .AddEndpointsApiExplorer()
    .AddSwagger(builder.Configuration)
    .AddAuth(builder.Configuration);



var app = builder.Build();

app.UseProblemDetails();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
        options.OAuthClientId(builder.Configuration["Authentication:ClientId"]);
        options.DisplayOperationId();
        options.DisplayRequestDuration();
    });
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

#pragma warning disable ASP0014
app.UseEndpoints(options => options.MapControllers().RequireAuthorization());
#pragma warning restore ASP0014

app.Run();

