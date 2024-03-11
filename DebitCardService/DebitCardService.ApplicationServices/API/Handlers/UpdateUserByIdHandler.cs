using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using DebitCardService.ApplicationServices.Components.HashPassword;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Commands;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class UpdateUserByIdHandler : IRequestHandler<UpdateUserByIdRequest, UpdateUserByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IPasswordHasher _passwordHasher;

    public UpdateUserByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IPasswordHasher passwordHasher)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _passwordHasher = passwordHasher;
    }

    public async Task<UpdateUserByIdResponse> Handle(UpdateUserByIdRequest request, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<DataAccess.Entities.User>(request);
        
        if (!string.IsNullOrEmpty(userEntity.HashedPassword))
        {
            userEntity.HashedPassword = _passwordHasher.CreateHashPassword(userEntity.HashedPassword!);
        }
        
        var command = new UpdateUserByIdCommand { Parameter = userEntity };
        var updatedUser = await _commandExecutor.Execute(command);

        if (updatedUser.Login == null)
        {
            return new UpdateUserByIdResponse { Error = new ErrorModel(ErrorType.NotFound) };
        }

        if (updatedUser.Id == 0)
        {
            return new UpdateUserByIdResponse { Error = new ErrorModel(ErrorType.ValidationError) };
        }

        var domainUpdatedUser = _mapper.Map<User>(updatedUser);
        var response = new UpdateUserByIdResponse
        {
            Data = domainUpdatedUser
        };
        return response;
    }
}
