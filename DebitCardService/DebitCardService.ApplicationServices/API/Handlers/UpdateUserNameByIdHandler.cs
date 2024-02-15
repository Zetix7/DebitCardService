using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Commands;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class UpdateUserNameByIdHandler : IRequestHandler<UpdateUserNameByIdRequest, UpdateUserNameByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateUserNameByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<UpdateUserNameByIdResponse> Handle(UpdateUserNameByIdRequest request, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<DataAccess.Entities.User>(request);
        var command = new UpdateUserNameByIdCommand { Parameter = userEntity };
        var updatedUser = await _commandExecutor.Execute(command);

        if (updatedUser.Login == null)
        {
            return new UpdateUserNameByIdResponse { Error = new ErrorModel(ErrorType.NotFound) };
        }

        var domainUpdatedUser = _mapper.Map<User>(updatedUser);
        var response = new UpdateUserNameByIdResponse
        {
            Data = domainUpdatedUser
        };
        return response;
    }
}
