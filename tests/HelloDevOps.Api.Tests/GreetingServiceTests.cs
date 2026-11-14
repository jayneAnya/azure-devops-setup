using HelloDevOps.Api.Services;

namespace HelloDevOps.Api.Tests;

public class GreetingServiceTests
{
    private readonly GreetingService _service = new();

    [Fact]
    public void Greet_WithName_ReturnsPersonalisedGreeting()
    {
        var result = _service.Greet("Jane");

        Assert.Equal("Hello, Jane! Welcome to Azure DevOps.", result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Greet_WithMissingName_FallsBackToWorld(string? name)
    {
        var result = _service.Greet(name);

        Assert.Equal("Hello, World! Welcome to Azure DevOps.", result);
    }

    [Fact]
    public void Greet_TrimsSurroundingWhitespace()
    {
        var result = _service.Greet("  Jane  ");

        Assert.Equal("Hello, Jane! Welcome to Azure DevOps.", result);
    }
}
