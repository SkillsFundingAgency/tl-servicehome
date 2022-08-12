using Sfa.Tl.Service.Home.Configuration;
using Sfa.Tl.Service.Home.Extensions;
using Sfa.Tl.Service.Home.Tests.Builders;

namespace Sfa.Tl.Service.Home.Tests.Extensions;
public class SettingsExtensionsTests
{
    [Fact]
    public void ConfigureLinkSettings_Returns_Expected_Value()
    {
        var targetLinkSettings = new LinkSettings();
        var linkSettings = new SettingsBuilder().BuildLinkSettings();

        targetLinkSettings.ConfigureLinkSettings(linkSettings);

        targetLinkSettings.Should().BeEquivalentTo(linkSettings);
    }
}
