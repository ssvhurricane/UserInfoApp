using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;
public class AppTestFactory : WebApplicationFactory<IStartup>
{
	protected override IWebHostBuilder CreateWebHostBuilder()
	{
		return WebHost.CreateDefaultBuilder()
			.UseStartup<IStartup>();
	}
}