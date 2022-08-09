using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sfa.Tl.Service.Home.Pages;

public class CookiesModel : PageModel
{
    private readonly ILogger<CookiesModel> _logger;

    public CookiesModel(ILogger<CookiesModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}