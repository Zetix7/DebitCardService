using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace DebitCardService.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    protected readonly IMediator _mediator;

    public ApiControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
        where TResponse : ErrorResponseBase
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState
                .Where(x => x.Value!.Errors.Any())
                .Select(x => new { property = x.Key, errors = x.Value!.Errors }));
        }

        var response = await _mediator.Send(request);

        if (response.Error != null)
        {
            return ErrorResponse(response.Error);
        }

        return Ok(response);
    }

    private IActionResult ErrorResponse(ErrorModel errorModel)
    {
        var httpCode = GetHttpStatusCode(errorModel.Error);
        return StatusCode((int)httpCode, errorModel);
    }

    private static HttpStatusCode GetHttpStatusCode(string errorType)
    {
        return errorType switch
        {
            ErrorType.NotFound => HttpStatusCode.NotFound,
            ErrorType.InternalServerError => HttpStatusCode.InternalServerError,
            ErrorType.Unauthorized => HttpStatusCode.Unauthorized,
            ErrorType.RequestTooLarge => HttpStatusCode.RequestEntityTooLarge,
            ErrorType.UnsupportedMediaType => HttpStatusCode.UnsupportedMediaType,
            ErrorType.UnsupportedMethod => HttpStatusCode.MethodNotAllowed,
            ErrorType.TooManyRequest => (HttpStatusCode)429,
            _ => HttpStatusCode.BadRequest
        };
    }
}
