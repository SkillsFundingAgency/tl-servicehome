using Sfa.Tl.Service.Home.Tests.Builders;
using Sfa.Tl.Service.Home.Tests.TestExtensions;
using Xunit.Abstractions;

namespace Sfa.Tl.Service.Home.Tests.IntegrationTests;

public class HomePageIntegrationTests
: IClassFixture<CustomWebApplicationFactory<Program>>
{
    //TODO: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0#mock-authentication

    // ReSharper disable once NotAccessedField.Local
    private readonly ITestOutputHelper _output;

    private readonly CustomWebApplicationFactory<Program> _fixture;

    public HomePageIntegrationTests(
        CustomWebApplicationFactory<Program> fixture,
        ITestOutputHelper output)
    {
        _fixture = fixture;
        _output = output;
    }

    [Fact]
    public async Task IndexPage_Has_Expected_Content_Type()
    {
        var client = _fixture.CreateClient();

        var response = await client.GetAsync("/");
        response.EnsureSuccessStatusCode();

        Assert.Equal("text/html; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
    }

    [Fact]
    public async Task IndexPage_Loads_Links()
    {
        var client = _fixture.CreateClient();

        var response = await client.GetAsync("/");
        response.EnsureSuccessStatusCode();

        Assert.Equal("text/html; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());

        var document = await response.GetDocumentAsync();

        document.ValidateLink("#tl-link-employer", SettingsBuilder.DefaultEmployerSupportSiteUrl);
        document.ValidateLink("#tl-link-provider", SettingsBuilder.DefaultProviderSupportSiteUrl);
        document.ValidateLink("#tl-link-provider-data", SettingsBuilder.DefaultProviderDataSiteUrl);
        document.ValidateLink("#tl-link-results", SettingsBuilder.DefaultResultsAndCertificationsSiteUrl);
    }
}
