using System.Text.Json;
using System.Text.Json.Nodes;

namespace Application.Abstractions.Extensions;
public static class StringEntensions
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    public static T DeserializeToObject<T>(this JsonNode json) where T : new()
    {
        return json.Deserialize<T>(_jsonOptions) ?? new T();
    }
}
