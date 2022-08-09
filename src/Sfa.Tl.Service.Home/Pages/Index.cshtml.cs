using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Sfa.Tl.Service.Home.Configuration;

namespace Sfa.Tl.Service.Home.Pages;

public class IndexModel : PageModel
{
    private readonly LinkSettings _linkSettings;
    private readonly ILogger<IndexModel> _logger;

    public string? EmployerSupportSiteUrl => 
        _linkSettings.EmployerSupportSiteUrl;

    public string? ProviderSupportSiteUrl =>
        _linkSettings.ProviderSupportSiteUrl;
    
    public string? ProviderDataSiteUrl =>
        _linkSettings.ProviderDataSiteUrl;

    public string? ResultsAndCertificationsSiteUrl =>
        _linkSettings.ResultsAndCertificationsSiteUrl;

    public IndexModel(
        IOptions<LinkSettings> linkSettings, 
        ILogger<IndexModel> logger)
    {
        _linkSettings = linkSettings?.Value ?? throw new ArgumentNullException(nameof(linkSettings));
        _logger = logger;
    }

    public void OnGet()
    {

    }
}