using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Stocks.Get.Responses;
public record GoogleNewsDtoResponse
{
    public int Position { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
    public string Thumbnail { get; set; }
    public string Thumbnail_small { get; set; }
    public string? Date { get; set; } 
    public DateTime? ParsedDate { get; set; }
    public Source Source { get; set; }
}

public record Source
{
    public string Name { get; set; }
    public string Icon { get; set; }
}
