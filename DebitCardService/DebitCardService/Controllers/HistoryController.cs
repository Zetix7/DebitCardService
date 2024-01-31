using DebitCardService.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DebitCardService.Controllers;

[ApiController]
[Route("[controller]")]
public class HistoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public HistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllHistory([FromQuery] GetAllHistoryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
