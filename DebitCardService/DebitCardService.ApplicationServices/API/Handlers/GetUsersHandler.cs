using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using DebitCardService.ApplicationServices.Components.ExchangeRate;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Queries;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        if (request.Login != null && request.Login!.Length < 8)
        {
            return new GetUsersResponse { Error = new ErrorModel(ErrorType.ValidationError) };
        }

        var query = new GetUsersQuery()
        {
            Login = request.Login,
        };
        var users = await _queryExecutor.Execute(query);

        if(users.Count == 0)
        {
            return new GetUsersResponse { Error = new ErrorModel(ErrorType.NotFound) };
        }
        var mappedUsers = _mapper.Map<List<User>>(users);

        var response = new GetUsersResponse()
        {
            Data = mappedUsers
        };

        return response;
    }
}
