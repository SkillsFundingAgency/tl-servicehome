using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sfa.Tl.Service.Home.Configuration;

namespace Sfa.Tl.Service.Home.Tests.IntegrationTests;

public class HomePageIntegrationTests 
    //: IClassFixture<WebApplicationFactory<Program>>
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    //private readonly WebApplicationFactory<Program> _factory;
    private readonly CustomWebApplicationFactory<Program> _factory;
    
    //public HomePageIntegrationTests(WebApplicationFactory<Program> factory)
    public HomePageIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        var projectDir = Directory.GetCurrentDirectory();
        var configPath = Path.Combine(projectDir, "appsettings.json");

        //_factory = factory.WithWebHostBuilder(builder =>
        //{
        //    builder.ConfigureAppConfiguration((context, conf) =>
        //    {
        //        conf.AddJsonFile(configPath);
        //    });

        //     builder.ConfigureServices(services =>
        //    {
        //        var serviceProvider = services.BuildServiceProvider();
        //    });

        //});
    }

    [Fact]
    public async Task HelloWorldTest()
    {

        /*
    var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                //var cfg = new ConfigurationRoot(new List<IConfigurationProvider>());
                //cfg[ConfigurationKeys.EnvironmentNameConfigKey] = "LOCAL";
                //cfg[ConfigurationKeys.ConfigurationStorageConnectionStringConfigKey] = "_";
                //cfg[ConfigurationKeys.ServiceNameConfigKey] = "Any";
                //cfg[ConfigurationKeys.VersionConfigKey] = "1.0";

                //builder.UseConfiguration(cfg);

                builder.ConfigureAppConfiguration(configBuilder =>
                {
                    var projectDir = Directory.GetCurrentDirectory();
                    var configPath = Path.Combine(projectDir, "appsettings.json");
                    configBuilder.AddJsonFile(configPath);

                });

                builder.ConfigureServices(services =>
                {

                });

                //builder.ConfigureTestContainer()
                // ... Configure test services
            });
        */

        var client = _factory.CreateClient();
        //...
        var response = await client.GetAsync("/");

        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("text/html; charset=utf-8",
            response.Content.Headers.ContentType.ToString());
    }
}
