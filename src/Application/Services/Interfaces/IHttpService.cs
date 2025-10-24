using System.Text.Json.Nodes;
using Application.HttpRequest;

namespace Application.Services.Interfaces;
public interface IHttpService
{
    Task<JsonNode?> GetAsync(HttpRequestBuilder httpRequestBuilder);
}
