
using Application.Abstractions.Messaging;
using Application.Stocks.Get.Queries;
using Application.Stocks.Get.Responses;
using SharedKernel;

namespace StocksApi.Endpoints.Stocks;

internal  sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("stocks", async (
            [AsParameters] GetStocksQuery query,
            IQueryHandler<GetStocksQuery, List<StockResponse>> handler,
            CancellationToken cancellationToken) =>
        {

            Result<List<StockResponse>> result = await handler.Handle(query, cancellationToken);

            return result.Value;
        })
        .WithTags(Tags.Todos);
        //.RequireAuthorization();
        //
    }
}
