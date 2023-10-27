using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MyLibrary.Api;
using MyLibrary.Api.Features;
using MyLibrary.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .ConfigureApplicationPartManager(manager =>
    {
        manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
    });

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddProblemDetailsConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger(builder.Configuration);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["Authentication:Domain"];
    options.Audience = builder.Configuration["Authentication:Audience"];
});

var app = builder.Build();

app.UseProblemDetails();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
        options.OAuthClientId(builder.Configuration["Authentication:ClientId"]);
    });
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

#pragma warning disable ASP0014
app.UseEndpoints(options => options.MapControllers().RequireAuthorization());
#pragma warning restore ASP0014

app.Run();

