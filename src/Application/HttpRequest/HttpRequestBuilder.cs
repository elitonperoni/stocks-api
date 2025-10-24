namespace Application.HttpRequest;
public record HttpRequestBuilder
{
    public Uri Uri { get; set; }
    public  string AuthorizationToken { get; set; }
}
