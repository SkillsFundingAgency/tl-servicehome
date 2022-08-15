using Sfa.Tl.Service.Home.Configuration;

namespace Sfa.Tl.Service.Home.Tests.Builders;

public class SettingsBuilder
{
    public const string DefaultEnvironment = "UNIT_TEST";

    public const string DefaultEmployerSupportSiteUrl = "https://test.tlevels.service.gov.uk/employers";
    public const string DefaultProviderSupportSiteUrl = "https://test.tlevels.service.gov.uk/providers";
    public const string DefaultProviderDataSiteUrl = "https://test.tlevels.service.gov.uk/providerdata";
    public const string DefaultResultsAndCertificationsSiteUrl = "https://test.tlevels.service.gov.uk/results";

    public ConfigurationOptions BuildConfigurationOptions(
        string? environment = null,
        LinkSettings? linkSettings = null) =>
        new()
        {
            Environment = environment ?? DefaultEnvironment,
            LinkSettings = linkSettings ?? BuildLinkSettings()
        };

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
