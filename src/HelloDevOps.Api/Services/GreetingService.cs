namespace HelloDevOps.Api.Services;

public interface IGreetingService
{
    string Greet(string? name);
}

public class GreetingService : IGreetingService
{
    public string Greet(string? name)
    {
        var cleaned = string.IsNullOrWhiteSpace(name) ? "World" : name.Trim();
        return $"Hello, {cleaned}! Welcome to Azure DevOps.";
    }
}
