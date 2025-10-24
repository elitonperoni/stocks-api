namespace Application.Stocks.Get.Responses;
public record StockResponse
{
    public int Id { get; set; }
    public string Stock { get; set; }
    public string Name { get; set; }
    public decimal Close { get; set; }
    public decimal Change { get; set; }
    public decimal Volume { get; set; }
    public string Logo { get; set; }
    public string Sector { get; set; }
    public string Type { get; set; }
}
