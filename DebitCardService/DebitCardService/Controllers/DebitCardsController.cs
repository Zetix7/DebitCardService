using DebitCardService.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DebitCardService.Controllers;

public class DebitCardsController : ApiControllerBase
{
    private readonly ILogger<DebitCardsController> _logger;

    public DebitCardsController(IMediator mediator, ILogger<DebitCardsController> logger) : base(mediator)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllDebitCards([FromQuery] GetAllDebitCardsRequest request)
    {
        _logger.LogInformation("We are in GetAllDebitCards endpoint GET");
        return HandleRequest<GetAllDebitCardsRequest, GetAllDebitCardsResponse>(request);
    }

    [HttpGet]
    [Route("{debitCardId}")]
    public Task<IActionResult> GetDebitCardById([FromRoute] int debitCardId)
    {
        _logger.LogInformation("We are in GetDebitCardById endpoint GET");
        var request = new GetDebitCardByIdRequest
        {
            Id = debitCardId
        };
        return HandleRequest<GetDebitCardByIdRequest, GetDebitCardByIdResponse>(request);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddDebitCard([FromBody] AddDebitCardRequest request)
    {
        _logger.LogInformation("We are in AddDebitCard endpoint POST");
        return HandleRequest<AddDebitCardRequest, AddDebitCardResponse>(request);
    }

    [HttpPut]
    [Route("{debitCardId}")]
    public Task<IActionResult> UpdateDebitCardActivity([FromRoute] int debitCardId, [FromBody] UpdateDebitCardRequest request)
    {
        _logger.LogInformation("We are in UpdateDebitCardActivity endpoint PUT");
        request.Id = debitCardId;
        return HandleRequest<UpdateDebitCardRequest, UpdateDebitCardResponse>(request);
    }

    [HttpDelete]
    [Route("{debitCardId}")]
    public Task<IActionResult> RemoveDebitCard([FromRoute] int debitCardId)
    {
        _logger.LogInformation("We are in RemoveDebitCard endpoint DELETE");
        var request = new RemoveDebitCardRequest { Id = debitCardId };
        return HandleRequest<RemoveDebitCardRequest, RemoveDebitCardResponse>(request);
    }
}
