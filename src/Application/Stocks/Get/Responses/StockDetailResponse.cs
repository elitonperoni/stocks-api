namespace Application.Stocks.Get.Responses;

public record StockDetailResponse
{
    public string Currency { get; init; }
    public decimal? MarketCap { get; init; }
    public string ShortName { get; init; }
    public string LongName { get; init; }
    public decimal RegularMarketChange { get; init; }
    public decimal RegularMarketChangePercent { get; init; }
    public string RegularMarketTime { get; init; }
    public decimal RegularMarketPrice { get; init; }
    public decimal RegularMarketDayHigh { get; init; }
    public string RegularMarketDayRange { get; init; }
    public decimal RegularMarketDayLow { get; init; }
    public decimal RegularMarketVolume { get; init; }
    public decimal RegularMarketPreviousClose { get; init; }
    public decimal RegularMarketOpen { get; init; }
    public string FiftyTwoWeekRange { get; init; }
    public decimal FiftyTwoWeekLow { get; init; }
    public decimal FiftyTwoWeekHigh { get; init; }
    public decimal? EarningsPerShare { get; init; }
    public decimal? PriceEarnings { get; init; }
    public string Symbol { get; init; }
    public string LogoUrl { get; init; }
    public string UsedInterval { get; init; }
    public string UsedRange { get; init; }
    public IReadOnlyList<HistoricalDataPriceResponse> HistoricalDataPrice { get; init; }
}
