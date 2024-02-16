using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.DataAccess.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DebitCardService.Controllers;

[ApiController]
[Route("[controller]")]
public class HistoryController : ApiControllerBase
{
    public HistoryController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllHistory([FromQuery] GetAllHistoryRequest request)
    {
        return HandleRequest<GetAllHistoryRequest, GetAllHistoryResponse>(request);
    }

    [HttpGet]
    [Route("{debitCardId}")]
    public Task<IActionResult> GetHistoryByDebitCardId([FromRoute] int debitCardId)
    {
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
        return HandleRequest<AddHistoryRequest, AddHistoryResponse>(request);
    }
}
