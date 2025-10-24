using Application.Abstractions.Messaging;
using Application.Stocks.Get.Queries;
using Application.Stocks.Get.Responses;
using SharedKernel;

namespace StocksApi.Endpoints.Stocks;
internal sealed class GetDetail : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("stocks/detail", async (
            [AsParameters] GetStocksDetailQuery query,
            IQueryHandler<GetStocksDetailQuery, StockDetailResponse?> handler,
            CancellationToken cancellationToken) =>
        {
            Result<StockDetailResponse?> result = await handler.Handle(query, cancellationToken);

            return result.Value;
        })
        .WithTags(Tags.Todos);
        //.RequireAuthorization();
    }
}
