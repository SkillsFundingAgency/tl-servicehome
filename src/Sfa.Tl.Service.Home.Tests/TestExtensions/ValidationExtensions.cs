using AngleSharp.Html.Dom;

namespace Sfa.Tl.Service.Home.Tests.TestExtensions;
public static class ValidationExtensions
{
    public static void ValidateLink(this IHtmlDocument document, string id, string expectedHref)
    {
        var linkElement = document.QuerySelector(id);
        linkElement.Should().NotBeNull($"element {id} should exist");
        var href = linkElement?.Attributes["href"]?.Value;
        href.Should().Be(expectedHref, $"href for {id} should be {expectedHref}");
    }
}
