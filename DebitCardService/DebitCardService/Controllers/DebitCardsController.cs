using DebitCardService.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DebitCardService.Controllers;

[ApiController]
[Route("[controller]")]
public class DebitCardsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DebitCardsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllDebitCards([FromQuery] GetAllDebitCardsRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    [Route("{debitCardId}")]
    public async Task<IActionResult> GetDebitCardById([FromRoute] int debitCardId)
    {
        var request = new GetDebitCardByIdRequest
        {
            Id = debitCardId
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddDebitCard([FromBody] AddDebitCardRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
