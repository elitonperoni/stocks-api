using SharedKernel;

namespace Domain.Stocks;
public sealed  class Stock : Entity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public decimal Close { get; set; }
    public decimal Change { get; set; }
    public decimal Volume { get; set; }
    public decimal Market_Cap { get; set; }
    public string Logo { get; set; }
    public string Sector { get; set; }
    public string Type { get; set; }
}
