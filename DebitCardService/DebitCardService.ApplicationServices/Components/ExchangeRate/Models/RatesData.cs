using Newtonsoft.Json;

namespace DebitCardService.ApplicationServices.Components.ExchangeRate.Models;

public class RatesData
{
    [JsonProperty("effectiveDate")]
    public string? Date { get; set; }
    [JsonProperty("bid")]
    public decimal Buy { get; set; }

    [JsonProperty("ask")]
    public decimal Sell { get; set; }
}
