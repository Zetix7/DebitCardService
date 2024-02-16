using DebitCardService.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DebitCardService.Controllers;

[ApiController]
[Route("[controller]")]
public class DebitCardsController : ApiControllerBase
{
    public DebitCardsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllDebitCards([FromQuery] GetAllDebitCardsRequest request)
    {
        return HandleRequest<GetAllDebitCardsRequest, GetAllDebitCardsResponse>(request);
    }

    [HttpGet]
    [Route("{debitCardId}")]
    public Task<IActionResult> GetDebitCardById([FromRoute] int debitCardId)
    {
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
        return HandleRequest<AddDebitCardRequest, AddDebitCardResponse>(request);
    }

    [HttpPut]
    [Route("{debitCardId}")]
    public Task<IActionResult> UpdateDebitCardActivity([FromRoute] int debitCardId, [FromBody] UpdateDebitCardActivityRequest request)
    {
        request.Id = debitCardId;
        return HandleRequest<UpdateDebitCardActivityRequest, UpdateDebitCardActivityResponse>(request);
    }

    [HttpDelete]
    [Route("{debitCardId}")]
    public Task<IActionResult> RemoveDebitCard([FromRoute] int debitCardId)
    {
        var request = new RemoveDebitCardRequest { Id = debitCardId };
        return HandleRequest<RemoveDebitCardRequest, RemoveDebitCardResponse>(request);
    }
}
