using DebitCardService.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DebitCardService.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ApiControllerBase
{

    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
    {
        return HandleRequest<GetUsersRequest, GetUsersResponse>(request);
    }

    [HttpGet]
    [Route("{userId}")]
    public Task<IActionResult> GetUserById([FromRoute] int userId)
    {
        var request = new GetUserByIdRequest { UserId = userId };
        return HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
    {
        return HandleRequest<AddUserRequest, AddUserResponse>(request);
    }

    [HttpPut]
    [Route("{userId}")]
    public Task<IActionResult> UpdateUserNameById([FromRoute] int userId, [FromBody] UpdateUserNameByIdRequest request)
    {
        request.Id = userId;
        return HandleRequest<UpdateUserNameByIdRequest, UpdateUserNameByIdResponse>(request);
    }

    [HttpDelete]
    [Route("{userId}")]
    public Task<IActionResult> RemoveUser([FromRoute] int userId)
    {
        var request = new RemoveUserRequest { Id = userId };
        return HandleRequest<RemoveUserRequest, RemoveUserResponse>(request);
    }
}
