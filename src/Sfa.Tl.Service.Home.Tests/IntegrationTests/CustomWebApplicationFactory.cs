using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sfa.Tl.Service.Home.Tests.IntegrationTests;

public class CustomWebApplicationFactory<Program>
    : WebApplicationFactory<Program> where Program : class
{
    private readonly WebApplicationFactory<Program> _factory;

    public CustomWebApplicationFactory(WebApplicationFactory<Program> factory)
    {
        //public CustomWebApplicationFactory<Program>();WebApplicationFactory<Program> factory)

        var projectDir = Directory.GetCurrentDirectory();
        var configPath = Path.Combine(projectDir, "appsettings.json");

        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureAppConfiguration((context, conf) =>
            {
                conf.AddJsonFile(configPath);
            });

            builder.ConfigureServices(services =>
            {
                var serviceProvider = services.BuildServiceProvider();
            });
        });
    }
}
