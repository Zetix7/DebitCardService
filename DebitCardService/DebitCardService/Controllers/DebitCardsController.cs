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
}
