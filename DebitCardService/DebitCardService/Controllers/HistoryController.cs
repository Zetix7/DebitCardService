﻿using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.DataAccess.CQRS.Queries;
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

    [HttpGet]
    [Route("{debitCardId}")]
    public async Task<IActionResult> GetHistoryByDebitCardId([FromRoute] int debitCardId)
    {
        var request = new GetHistoryByDebitCardIdRequest
        {
            DebitCardId = debitCardId
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddHistory([FromBody] AddHistoryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
