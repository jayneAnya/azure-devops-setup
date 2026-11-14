using HelloDevOps.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IGreetingService, GreetingService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/health", () => Results.Ok(new { status = "Healthy", timestampUtc = DateTime.UtcNow }))
   .WithName("GetHealth");

app.MapGet("/greet/{name}", (string name, IGreetingService greetings) =>
        Results.Ok(new { message = greetings.Greet(name) }))
   .WithName("Greet");

app.Run();

public partial class Program { }
