using DebitCardService.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DebitCardService.Controllers;

public class UsersController : ApiControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
    {
        _logger.LogInformation("We are in GetAllUsers endpoint GET");
        return HandleRequest<GetUsersRequest, GetUsersResponse>(request);
    }

    [HttpGet]
    [Route("{userId}")]
    public Task<IActionResult> GetUserById([FromRoute] int userId)
    {
        _logger.LogInformation("We are in GetAllUserById endpoint GET");
        var request = new GetUserByIdRequest { UserId = userId };
        return HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
    {
        _logger.LogInformation("We are in AddUser endpoint POST");
        return HandleRequest<AddUserRequest, AddUserResponse>(request);
    }

    [HttpPut]
    [Route("{userId}")]
    public Task<IActionResult> UpdateUserNameById([FromRoute] int userId, [FromBody] UpdateUserByIdRequest request)
    {
        _logger.LogInformation("We are in UpdateUserNameById endpoint PUT");
        request.Id = userId;
        return HandleRequest<UpdateUserByIdRequest, UpdateUserByIdResponse>(request);
    }

    [HttpDelete]
    [Route("{userId}")]
    public Task<IActionResult> RemoveUser([FromRoute] int userId)
    {
        _logger.LogInformation("We are in RemoveUser endpoint DELETE");
        var request = new RemoveUserRequest { Id = userId };
        return HandleRequest<RemoveUserRequest, RemoveUserResponse>(request);
    }
}
