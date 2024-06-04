using DebitCardService.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DebitCardService.Controllers;

public class HistoryController : ApiControllerBase
{
    private readonly ILogger<HistoryController> _logger;

    public HistoryController(IMediator mediator, ILogger<HistoryController> logger) : base(mediator)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllHistory([FromQuery] GetAllHistoryRequest request)
    {
        _logger.LogInformation("We are in GetAllHistory endpoint GET");
        return HandleRequest<GetAllHistoryRequest, GetAllHistoryResponse>(request);
    }

    [HttpGet]
    [Route("{debitCardId}")]
    public Task<IActionResult> GetHistoryByDebitCardId([FromRoute] int debitCardId)
    {
        _logger.LogInformation("We are in GetHistoryByDebitCardId endpoint GET");
        var request = new GetHistoryByDebitCardIdRequest
        {
            DebitCardId = debitCardId
        };
        return HandleRequest<GetHistoryByDebitCardIdRequest, GetHistoryByDebitCardIdResponse>(request);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddHistory([FromBody] AddHistoryRequest request)
    {
        _logger.LogInformation("We are in AddHistory endpoint POST");
        return HandleRequest<AddHistoryRequest, AddHistoryResponse>(request);
    }
}
