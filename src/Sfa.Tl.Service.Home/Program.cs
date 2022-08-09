using Sfa.Tl.Service.Home.Configuration;
using Sfa.Tl.Service.Home.Extensions;
using Sfa.Tl.Service.Home.Security;

var builder = WebApplication.CreateBuilder(args);

var siteConfiguration = builder.Configuration.LoadConfigurationOptions();

builder.Services
    .AddApplicationInsightsTelemetry();

builder.Services
    .Configure<LinkSettings>(x =>
    {
        x.ConfigureLinkSettings(siteConfiguration.LinkSettings);
    });

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = _ => true;
    options.Secure = CookieSecurePolicy.Always;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddResponseCaching();

builder.Services.AddRazorPages();

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddHsts(options =>
    {
        options.MaxAge = TimeSpan.FromDays(365);
    });
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseXContentTypeOptions()
   .UseReferrerPolicy(opts => opts.NoReferrer())
   .UseXXssProtection(opts => opts.EnabledWithBlockMode())
   .UseCsp(options => options
       .FrameAncestors(s => s.None())
       .ObjectSources(s => s.None())
       .ScriptSources(s => s
           .CustomSources("https:",
                "https://www.google-analytics.com/analytics.js",
                "https://www.googletagmanager.com/",
                "https://tagmanager.google.com/")
           .UnsafeInline()
       ))
       .Use(async (context, next) =>
       {
           context.Response.Headers.Add("Expect-CT", "max-age=0, enforce");
           context.Response.Headers.Add("Permissions-Policy", SecurityPolicies.PermissionsList);
           await next.Invoke();
       });

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapFallback("{*path}", 
    () => Results.Redirect("/Error/404"));

app.MapRazorPages();

app.UseResponseCaching();

app.Run();
