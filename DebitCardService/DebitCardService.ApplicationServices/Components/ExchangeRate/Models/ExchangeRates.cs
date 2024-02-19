using Newtonsoft.Json;

namespace DebitCardService.ApplicationServices.Components.ExchangeRate.Models;

public class ExchangeRates
{
    [JsonProperty("code")]
    public string? Currency { get; set; }

    [JsonProperty("rates")]
    public List<RatesData>? Rates { get; set; }
}
