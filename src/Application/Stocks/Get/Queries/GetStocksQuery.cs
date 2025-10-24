using Application.Abstractions.Messaging;
using Application.Stocks.Get.Responses;

namespace Application.Stocks.Get.Queries;
public sealed record GetStocksQuery(
    string? searchTerm,
    string? type,
    string? sector
    ) : IQuery<List<StockResponse>>;
