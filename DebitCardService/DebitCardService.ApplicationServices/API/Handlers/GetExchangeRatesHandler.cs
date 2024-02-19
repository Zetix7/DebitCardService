using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using DebitCardService.ApplicationServices.Components.ExchangeRate;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetExchangeRatesHandler : IRequestHandler<GetExchangeRatesRequest, GetExchangeRatesResponse>
{
    private readonly IExchangeRatesConnector _exchangeRatesConnector;

    public GetExchangeRatesHandler(IExchangeRatesConnector exchangeRatesConnector)
    {
        _exchangeRatesConnector = exchangeRatesConnector;
    }

    public async Task<GetExchangeRatesResponse> Handle(GetExchangeRatesRequest request, CancellationToken cancellationToken)
    {
        if (request.Currency!.Length != 3)
        {
            return new GetExchangeRatesResponse { Error = new ErrorModel(ErrorType.ValidationError) };
        }

        var exchangeRates = await _exchangeRatesConnector.GetExchangeRates(request.Currency!);

        if (exchangeRates == null)
        {
            return new GetExchangeRatesResponse { Error = new ErrorModel(ErrorType.NotFound) };
        }

        var response = new GetExchangeRatesResponse
        {
            Data = exchangeRates
        };
        return response;
    }
}
