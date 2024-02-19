using DebitCardService.ApplicationServices.Components.ExchangeRate.Models;

namespace DebitCardService.ApplicationServices.Components.ExchangeRate;

public interface IExchangeRatesConnector
{
    Task<ExchangeRates> GetExchangeRates(string currency);
}
