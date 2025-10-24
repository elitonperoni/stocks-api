using System.Net.Http.Headers;

namespace StocksApi.Extensions;

public static class HttpClientExtensions
{
    public static void AddAuthorization(this HttpClient httpClient, string? authorizationToken = null)       
    {
        if (!string.IsNullOrEmpty(authorizationToken))
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", authorizationToken);
    }
}
