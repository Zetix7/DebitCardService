using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Commands;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<DataAccess.Entities.User>(request);
        var command = new AddUserCommand { Parameter = user };
        var userFromDb = await _commandExecutor.Execute(command);
        var mappedUser = _mapper.Map<User>(userFromDb);
        var response = new AddUserResponse
        {
            Data = mappedUser
        };
        return response;
    }
}
