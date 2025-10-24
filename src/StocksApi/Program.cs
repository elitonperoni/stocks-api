using System.Reflection;
using Application;
using Application.HttpRequest.ApiKeys;
using HealthChecks.UI.Client;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Serilog;
using StocksApi;
using StocksApi.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Configuration
    .AddEnvironmentVariables();

builder.Services.AddSwaggerGenWithAuth();

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

WebApplication app = builder.Build();

app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();   
}

//app.MapHealthChecks("health", new HealthCheckOptions
//{
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//});

app.UseRequestContextLogging();
app.UseSerilogRequestLogging();
app.UseExceptionHandler();
app.UseCors();

app.MapControllers();

await app.RunAsync();
