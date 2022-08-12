using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Sfa.Tl.Service.Home.Configuration;

namespace Sfa.Tl.Service.Home.Pages;

public class IndexModel : PageModel
{
    private readonly LinkSettings _linkSettings;
    private readonly ILogger<IndexModel> _logger;
    
    public string? EmployerSupportSiteUrl { get; private set; }

    public string? ProviderSupportSiteUrl { get; private set; }

    public string? ProviderDataSiteUrl { get; private set; }

    public string? ResultsAndCertificationsSiteUrl { get; private set; }

    public IndexModel(
        IOptions<LinkSettings> linkSettings, 
        ILogger<IndexModel> logger)
    {
        _linkSettings = linkSettings.Value ?? throw new ArgumentNullException(nameof(linkSettings));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void OnGet()
    {
        EmployerSupportSiteUrl = _linkSettings.EmployerSupportSiteUrl;
        ProviderSupportSiteUrl = _linkSettings.ProviderSupportSiteUrl;
        ProviderDataSiteUrl = _linkSettings.ProviderDataSiteUrl;
        ResultsAndCertificationsSiteUrl = _linkSettings.ResultsAndCertificationsSiteUrl;
    }
}