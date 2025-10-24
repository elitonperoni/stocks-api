namespace Application.Stocks.Get.Responses;

public record HistoricalDataPriceResponse
{
    public long Date { get; init; }
    public decimal Open { get; init; }
    public decimal High { get; init; }
    public decimal Low { get; init; }
    public decimal Close { get; init; }
    public decimal Volume { get; init; }
    public decimal? AdjustedClose { get; init; }
}
