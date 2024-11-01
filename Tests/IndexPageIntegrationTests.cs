using System.Net;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tests;
public class IndexPageIntegrationTests
  : IClassFixture<AppTestFactory>
{
	private readonly WebApplicationFactory<IStartup> _factory;

    private readonly HttpClient _client;
	public IndexPageIntegrationTests(
      AppTestFactory factory)
	{
		_factory = factory;

          _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
	}

    [Fact]
    public async Task Get_User_Filter()
    {
        // Arrange.
        var defaultPage = await _client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

        // Act.
        var response = await _client.SendAsync(
            (IHtmlFormElement)content.QuerySelector("form[id='testFilterId']"),
            (IHtmlButtonElement)content.QuerySelector("input[id='testFilterIdBtn']"));

        // Assert.
        Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        Assert.Equal("/", response.Headers.Location.OriginalString);
    }
}