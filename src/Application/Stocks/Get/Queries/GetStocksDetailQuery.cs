using Application.Abstractions.Messaging;
using Application.Stocks.Get.Responses;

namespace Application.Stocks.Get.Queries;

public sealed record GetStocksDetailQuery(
    string stock,
    string range 
    ) : IQuery<StockDetailResponse?>;
