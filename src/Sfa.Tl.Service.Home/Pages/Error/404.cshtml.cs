using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sfa.Tl.Service.Home.Pages;

public class Error404Model : PageModel
{
    private readonly ILogger<Error404Model> _logger;

    public Error404Model(ILogger<Error404Model> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}