using AngleSharp.Html.Dom;
using AngleSharp.Io;
using AngleSharp;
using System.Net.Http.Headers;

namespace Sfa.Tl.Service.Home.Tests.TestExtensions;

public static class HtmlHelperExtensions
{
    public static async Task<IHtmlDocument> GetDocumentAsync(this HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        var document = await BrowsingContext.New()
            .OpenAsync(ResponseFactory, CancellationToken.None);
        return (IHtmlDocument)document;

        void ResponseFactory(VirtualResponse htmlResponse)
        {
            if (response.RequestMessage is null) throw new ArgumentNullException(nameof(response));

            htmlResponse
                .Address(response.RequestMessage.RequestUri)
            .Status(response.StatusCode);

            MapHeaders(response.Headers);
            MapHeaders(response.Content.Headers);

            htmlResponse.Content(content);

            void MapHeaders(HttpHeaders headers)
            {
                foreach (var header in headers)
                {
                    foreach (var value in header.Value)
                    {
                        htmlResponse.Header(header.Key, value);
                    }
                }
            }
        }
    }
}
