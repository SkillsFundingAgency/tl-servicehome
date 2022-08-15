using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sfa.Tl.Service.Home.Configuration;
using Sfa.Tl.Service.Home.Extensions;
using Sfa.Tl.Service.Home.Tests.Builders;

namespace Sfa.Tl.Service.Home.Tests.IntegrationTests;

public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((_, conf) =>
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");
            conf.AddJsonFile(configPath, true);
        });

        builder.ConfigureServices(services =>
        {
            //Replace settings with known test values
            services
                .Configure<LinkSettings>(x =>
                {
                    var siteConfiguration = new SettingsBuilder().BuildConfigurationOptions();
                    x.ConfigureLinkSettings(siteConfiguration.LinkSettings);
                });

            services.BuildServiceProvider();
        });
    }
}
