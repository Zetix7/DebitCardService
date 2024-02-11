﻿using DebitCardService.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DebitCardService.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<IActionResult> GetUserById([FromRoute] int userId)
    {
        var request = new GetUserByIdRequest
        {
            UserId = userId
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("BAD_REQUEST_678");
        }

        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    [Route("{userId}")]
    public async Task<IActionResult> UpdateUserNameById([FromRoute] int userId, [FromBody] UpdateUserNameByIdRequest request)
    {
        request.Id = userId;
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{userId}")]
    public async Task<IActionResult> RemoveUser([FromRoute] int userId)
    {
        var request = new RemoveUserRequest { Id = userId };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
