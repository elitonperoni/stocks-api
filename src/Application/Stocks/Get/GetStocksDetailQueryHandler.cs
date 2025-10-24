using System.Text.Json.Nodes;
using Application.Abstractions.Extensions;
using Application.Abstractions.Messaging;
using Application.HttpRequest;
using Application.HttpRequest.ApiKeys;
using Application.Services.Interfaces;
using Application.Stocks.Get.Queries;
using Application.Stocks.Get.Responses;
using Microsoft.Extensions.Options;
using SharedKernel;

namespace Application.Stocks.Get;
internal sealed class GetStocksDetailQueryHandler(
    IHttpService httpService,
    IOptions<ApiKeys> apiKeysOptions
    )
    : IQueryHandler<GetStocksDetailQuery, StockDetailResponse?>
{
    public async Task<Result<StockDetailResponse?>> Handle(GetStocksDetailQuery query, CancellationToken cancellationToken)
    {
        HttpRequestBuilder httpRequest = new()
        {
            Uri = BuildUri(query),
            AuthorizationToken = apiKeysOptions.Value.BrapiApiKey
        };

        JsonNode? response = await httpService.GetAsync(httpRequest);

        StockDetailResponse? stock = response?["results"]?.AsArray()?.FirstOrDefault()?.DeserializeToObject<StockDetailResponse>();        

        return await Task.FromResult(Result<StockDetailResponse>.Success(stock));
    }

    private Uri BuildUri(GetStocksDetailQuery query)
    {        
        return new Uri($"https://brapi.dev/api/quote/{query.stock}?interval=1d&range={query.range}");
    }
}
