using Sfa.Tl.Service.Home.Extensions;

namespace Sfa.Tl.Service.Home.Tests.Extensions;

public class PageExtensionsDataTests
{
    [Fact]
    public void GetServiceName_Returns_Expected_Value()
    {
        PageExtensions.GetServiceName().Should().Be("T Levels Service Home");
    }

    private const string DefaultServiceName = "T Levels Service Home";
    [Theory(DisplayName = "PageExtensions Data Tests")]
    [InlineData(true, null, DefaultServiceName + " - GOV.UK")]
    [InlineData(true, "", DefaultServiceName + " - GOV.UK")]
    [InlineData(true, DefaultServiceName + "", DefaultServiceName + " - GOV.UK")]
    [InlineData(true, "Page Title", "Page Title - " + DefaultServiceName + " - GOV.UK")]
    [InlineData(false, null, "Error: " + DefaultServiceName + " - GOV.UK")]
    [InlineData(false, "", "Error: " + DefaultServiceName + " - GOV.UK")]
    [InlineData(false, DefaultServiceName + "", "Error: " + DefaultServiceName + " - GOV.UK")]
    [InlineData(false, "Page Title", "Error: Page Title - " + DefaultServiceName + " - GOV.UK")]
    public void DataTests(bool isValid, string title, string result)
    {
        var generatedTitle = PageExtensions.GenerateTitle(title, isValid);
        generatedTitle.Should().Be(result);
    }

    [Theory(DisplayName = "PageExtensions Data Tests")]
    [InlineData(null, DefaultServiceName + " - GOV.UK")]
    [InlineData("", DefaultServiceName + " - GOV.UK")]
    [InlineData(DefaultServiceName + "", DefaultServiceName + " - GOV.UK")]
    [InlineData("Page Title", "Page Title - " + DefaultServiceName + " - GOV.UK")]
    public void DataTestsWithDefaultValue(string title, string result)
    {
        var generatedTitle = PageExtensions.GenerateTitle(title);

        generatedTitle.Should().Be(result);
    }
}