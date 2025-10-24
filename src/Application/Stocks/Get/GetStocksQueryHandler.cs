using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Nodes;
using Application.Abstractions.Extensions;
using Application.Abstractions.Messaging;
using Application.HttpRequest;
using Application.Services.Interfaces;
using Application.Stocks.Get.Queries;
using Application.Stocks.Get.Responses;
using SharedKernel;

namespace Application.Stocks.Get;
internal sealed class GetStocksQueryHandler(IHttpService httpService) : IQueryHandler<GetStocksQuery, List<StockResponse>>
{
    private const string U = "https://brapi.dev/api/quote/list";

    public async Task<Result<List<StockResponse>>> Handle(GetStocksQuery query, CancellationToken cancellationToken)
    {
        HttpRequestBuilder httpRequest = new()
        {
            Uri = BuildUri(query, U),
        };

        JsonNode? response = await httpService.GetAsync(httpRequest);

        List<StockResponse> stock = response?["stocks"]?.DeserializeToObject<List<StockResponse>>() ?? new();

        int index = 1;
        stock.ForEach(p =>
        {
            p.Id = index;
            index += 1;
        });

        return await Task.FromResult(Result<List<StockResponse>>.Success(stock));
    }
    private Uri BuildUri(GetStocksQuery query, string uri)
    {
        var builder = new UriBuilder(uri);
        NameValueCollection queryParams = System.Web.HttpUtility.ParseQueryString(string.Empty);

        queryParams["sortBy"] = "volume";
        queryParams["sortOrder"] = "desc";
        queryParams["page"] = "1";
        queryParams["limit"] = "200";

        if (string.IsNullOrEmpty(query.searchTerm) && string.IsNullOrEmpty(query.type) && string.IsNullOrEmpty(query.sector))
        {
            queryParams["type"] = "stock";
        }
        else
        {
            if (!string.IsNullOrEmpty(query.searchTerm))
                queryParams["search"] = query.searchTerm;

            if (!string.IsNullOrEmpty(query.type))
                queryParams["type"] = query.type;

            if (!string.IsNullOrEmpty(query.sector))
                queryParams["sector"] = query.sector;
        }

        builder.Query = queryParams.ToString();
        return builder.Uri;
    }
}
