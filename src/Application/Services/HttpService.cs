using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;
using Application.Extensions;
using Application.HttpRequest;
using Application.Services.Interfaces;
using Application.Stocks.Get.Queries;

namespace Application.Services;
public class HttpService : IHttpService
{
    public async Task<JsonNode?> GetAsync(HttpRequestBuilder httpRequestBuilder)
    {
        try
        {
            using var client = new HttpClient();

            if (!string.IsNullOrEmpty(httpRequestBuilder.AuthorizationToken))            
                client.AddAuthorization(httpRequestBuilder.AuthorizationToken);                

            HttpResponseMessage response = await client.GetAsync(httpRequestBuilder.Uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using Stream stream = await response.Content.ReadAsStreamAsync();
                JsonNode? node = await JsonNode.ParseAsync(stream);
                return node as JsonObject;
            }

            return null;
        }        
        catch
        {
            return null;
        }
    }
}
