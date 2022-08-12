using Microsoft.Extensions.Options;

namespace Sfa.Tl.Service.Home.Tests.TestExtensions;

public static class OptionsExtensions
{
    public static IOptions<T> ToOptions<T>(this T? settings)
        where T : class =>
        new Func<IOptions<T>>(() =>
        {
            var options = Substitute.For<IOptions<T>>();
            options.Value.Returns(settings);
            return options;
        }).Invoke();
}
