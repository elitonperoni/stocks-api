using System.Collections;
using Application.Abstractions.Messaging;
using Application.Extensions;
using Application.HttpRequest.ApiKeys;
using Application.Stocks.Get.Queries;
using Application.Stocks.Get.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using SerpApi;
using SharedKernel;

namespace Application.Stocks.Get;
public class GetNewsStockQueryHandler(IOptions<ApiKeys> apiKeysOptions) : IQueryHandler<GetNewsStockQuery, List<GoogleNewsDtoResponse>>
{
    public Task<Result<List<GoogleNewsDtoResponse>>> Handle(GetNewsStockQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var ht = new Hashtable
            {
                { "engine", "google_news" },
                { "hl", "pt-br" },
                { "gl", "br" },
                { "q", $"Ação: {query.stock}, últimas notícias" }
            };

            var search = new GoogleSearch(ht, apiKeysOptions.Value.SerpApiKey);
            JObject data = search.GetJson();

            var googleNewsDtoResponses = data["news_results"]?
                    .ToObject<List<GoogleNewsDtoResponse>>().ToList();

            googleNewsDtoResponses?.ForEach(p => p.ParsedDate = p.Date.ParseCustomDate());

            var orderedList = googleNewsDtoResponses?.OrderByDescending(p => p.ParsedDate).Take(6).ToList();

            return Task.FromResult(Result<List<GoogleNewsDtoResponse>>.Success(orderedList ?? new List<GoogleNewsDtoResponse>()));
        }
        catch
        {
            return Task.FromResult((Result<List<GoogleNewsDtoResponse>>)Result<List<GoogleNewsDtoResponse>>.Failure(new Error("", "", ErrorType.Failure)));
        }
    }
}
