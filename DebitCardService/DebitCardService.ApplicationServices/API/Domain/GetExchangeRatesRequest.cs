using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetExchangeRatesRequest : IRequest<GetExchangeRatesResponse>
{
    public string? Currency {get; set;}
}
