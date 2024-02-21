using DebitCardService.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DebitCardService.Controllers;

[AllowAnonymous]
public class ExchangeRatesController : ApiControllerBase
{
    private readonly ILogger<ExchangeRatesController> _logger;

    public ExchangeRatesController(IMediator mediator, ILogger<ExchangeRatesController> logger) : base(mediator)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("{currency}")]
    public Task<IActionResult> GetCurrentExchangeRates([FromRoute] string currency)
    {
        _logger.LogInformation("We are in GetCurrentExchangeRates endpoint GET");
        var request = new GetExchangeRatesRequest { Currency = currency };
        return HandleRequest<GetExchangeRatesRequest, GetExchangeRatesResponse>(request);
    }
}
