using RestSharp;
using Newtonsoft.Json;
using DebitCardService.ApplicationServices.Components.ExchangeRate.Models;

namespace DebitCardService.ApplicationServices.Components.ExchangeRate;

public class ExchangeRatesConnector : IExchangeRatesConnector
{
    private readonly RestClient _restClient;
    private readonly string url = "https://api.nbp.pl/api/";
    private readonly string jsonFormat = "json";

    public ExchangeRatesConnector()
    {
        _restClient = new RestClient(url);
    }

    public async Task<ExchangeRates> GetExchangeRates(string currency)
    {
        var request = new RestRequest("exchangerates/rates/c/" + currency + "/", Method.Get);
        request.AddParameter("format", jsonFormat);
        var queryResult = await _restClient.ExecuteAsync(request);
        
        if (queryResult.Content == "404 NotFound - Not Found - Brak danych")
        {
            return null!;
        }
        
        var exchangeRates = JsonConvert.DeserializeObject<ExchangeRates>(queryResult.Content!);
        return exchangeRates!;
    }
}
// mojedane@mobi-me.pl