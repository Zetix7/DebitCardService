using RestSharp;
using Newtonsoft.Json;
using DebitCardService.ApplicationServices.Components.ExchangeRate.Models;
using Microsoft.Extensions.Configuration;

namespace DebitCardService.ApplicationServices.Components.ExchangeRate;

public class ExchangeRatesConnector : IExchangeRatesConnector
{
    private readonly IConfiguration _configuration;
    private readonly RestClient _restClient;

    public ExchangeRatesConnector(IConfiguration configuration)
    {
        _configuration = configuration;
        _restClient = new RestClient(_configuration.GetConnectionString("ExchangeRatesConnection:Url")!);//["ConnectionStrings:ExchangeRatesConnection:Url"]!);
    }

    public async Task<ExchangeRates> GetExchangeRates(string currency)
    {
        var request = new RestRequest("exchangerates/rates/c/" + currency + "/", Method.Get);
        request.AddParameter("format", _configuration.GetConnectionString("ExchangeRatesConnection:JsonFormat"));
        var queryResult = await _restClient.ExecuteAsync(request);
        
        if (queryResult.Content == "404 NotFound - Not Found - Brak danych")
        {
            return null!;
        }
        
        var exchangeRates = JsonConvert.DeserializeObject<ExchangeRates>(queryResult.Content!);
        return exchangeRates!;
    }
}
