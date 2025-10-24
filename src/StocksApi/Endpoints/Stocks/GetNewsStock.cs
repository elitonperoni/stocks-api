using Application.Abstractions.Messaging;
using Application.Stocks.Get.Queries;
using Application.Stocks.Get.Responses;
using SharedKernel;

namespace StocksApi.Endpoints.Stocks;

internal sealed class GetNewsStock : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("stocks/news", async (
            [AsParameters] GetNewsStockQuery query,
            IQueryHandler<GetNewsStockQuery, List<GoogleNewsDtoResponse>> handler,
            CancellationToken cancellationToken) =>
        {

            Result<List<GoogleNewsDtoResponse>> result = await handler.Handle(query, cancellationToken);

            return result.Value;
        })
        .WithTags(Tags.Todos);
        //.RequireAuthorization();
    }
}
