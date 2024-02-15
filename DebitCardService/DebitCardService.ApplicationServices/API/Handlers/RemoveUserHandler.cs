using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Commands;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class RemoveUserHandler : IRequestHandler<RemoveUserRequest, RemoveUserResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public RemoveUserHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
    {
        var userEntity = new DataAccess.Entities.User { Id = request.Id };
        var command = new RemoveUserCommand { Parameter = userEntity };
        var userFromDb = await _commandExecutor.Execute(command);
        
        if (userFromDb.FirstName == null)
        {
            return new RemoveUserResponse { Error = new ErrorModel(ErrorType.NotFound) };
        }
        
        var domainUser = _mapper.Map<User>(userFromDb);
        var response = new RemoveUserResponse { Data = domainUser };
        return response;
    }
}
