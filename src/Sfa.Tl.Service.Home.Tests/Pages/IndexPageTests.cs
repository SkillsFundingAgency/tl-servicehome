using Microsoft.Extensions.Logging;
using Sfa.Tl.Service.Home.Pages;
using Sfa.Tl.Service.Home.Tests.Builders;
using Sfa.Tl.Service.Home.Tests.TestExtensions;

namespace Sfa.Tl.Service.Home.Tests.Pages;

public class IndexPageTests
{
    [Fact]
    public void IndexModel_OnGet_Populates_Page_Properties()
    {
        var settingsBuilder = new SettingsBuilder();
        var linkOptions = settingsBuilder.BuildLinkSettings().ToOptions();

        var pageModel = new IndexModel(linkOptions, Substitute.For<ILogger<IndexModel>>());

        pageModel.OnGet();

        pageModel.EmployerSupportSiteUrl.Should().Be(settingsBuilder.DefaultEmployerSupportSiteUrl);
        pageModel.ProviderSupportSiteUrl.Should().Be(settingsBuilder.DefaultProviderSupportSiteUrl);
        pageModel.ProviderDataSiteUrl.Should().Be(settingsBuilder.DefaultProviderDataSiteUrl);
        pageModel.ResultsAndCertificationsSiteUrl.Should().Be(settingsBuilder.DefaultResultsAndCertificationsSiteUrl);
    }
}
