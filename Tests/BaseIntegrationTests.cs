using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tests;
public class BaseIntegrationTests 
  : IClassFixture<AppTestFactory>
{
	private readonly WebApplicationFactory<IStartup> _factory;
	public BaseIntegrationTests(
      AppTestFactory factory)
	{
		_factory = factory;
	}

    [Theory]
    [InlineData("/")]
    [InlineData("/Index")] 
    [InlineData("/Create")]
    [InlineData("/More")]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    {
        // Arrange.
        var client = _factory.CreateClient();

        // Act.
        var response = await client.GetAsync(url);

        // Assert.
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("text/html; charset=utf-8", 
            response.Content.Headers.ContentType.ToString());
    }

}