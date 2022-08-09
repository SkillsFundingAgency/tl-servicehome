using Sfa.Tl.Service.Home.Configuration;

namespace Sfa.Tl.Service.Home.Extensions;

public static class SettingsExtensions
{
    public static void ConfigureLinkSettings(this LinkSettings settings, LinkSettings? fromSettings)
    {
        if (fromSettings == null) throw new ArgumentNullException(nameof(fromSettings));

        settings.EmployerSupportSiteUrl = fromSettings.EmployerSupportSiteUrl;
        settings.ProviderSupportSiteUrl = fromSettings.ProviderSupportSiteUrl;
        settings.ProviderDataSiteUrl = fromSettings.ProviderDataSiteUrl;
        settings.ResultsAndCertificationsSiteUrl = fromSettings.ResultsAndCertificationsSiteUrl;
    }
}