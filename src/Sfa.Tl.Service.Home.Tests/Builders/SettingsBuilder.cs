using Sfa.Tl.Service.Home.Configuration;

namespace Sfa.Tl.Service.Home.Tests.Builders;

public class SettingsBuilder
{
    public string DefaultEmployerSupportSiteUrl => "https://test.tlevels.service.gov.uk/employers";

    //public const string DefaultEmployerSupportSiteUrl = "https://test.tlevels.service.gov.uk/employers";
    public string DefaultProviderSupportSiteUrl => "https://test.tlevels.service.gov.uk/providers";
    public string DefaultProviderDataSiteUrl => "https://test.tlevels.service.gov.uk/providerdata";
    public string DefaultResultsAndCertificationsSiteUrl => "https://test.tlevels.service.gov.uk/results";

    public LinkSettings BuildLinkSettings(
        string? employerSupportSiteUrl = null,
        string? providerSupportSiteUrl = null,
        string? providerDataSiteUrl = null,
        string? resultsAndCertificationsSiteUrl = null) =>
        new()
        {
            EmployerSupportSiteUrl = employerSupportSiteUrl ?? DefaultEmployerSupportSiteUrl,
            ProviderSupportSiteUrl = providerSupportSiteUrl ?? DefaultProviderSupportSiteUrl,
            ProviderDataSiteUrl = providerDataSiteUrl ?? DefaultProviderDataSiteUrl,
            ResultsAndCertificationsSiteUrl = resultsAndCertificationsSiteUrl ?? DefaultResultsAndCertificationsSiteUrl
        };
}
