using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using DebitCardService.ApplicationServices.Components.HashPassword;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Commands;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IPasswordHasher _passwordHasher;

    public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor, IPasswordHasher passwordHasher)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _passwordHasher = passwordHasher;
    }

    public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<DataAccess.Entities.User>(request);

        if (!string.IsNullOrEmpty(user.HashedPassword))
        {
            user.HashedPassword = _passwordHasher.CreateHashPassword(user.HashedPassword!);
        }

        var command = new AddUserCommand { Parameter = user };
        var userFromDb = await _commandExecutor.Execute(command);
        
        if (userFromDb == null)
        {
            return new AddUserResponse { Error = new ErrorModel(ErrorType.ValidationError) };
        }
        
        var mappedUser = _mapper.Map<User>(userFromDb);
        var response = new AddUserResponse
        {
            Data = mappedUser
        };
        return response;
    }
}
