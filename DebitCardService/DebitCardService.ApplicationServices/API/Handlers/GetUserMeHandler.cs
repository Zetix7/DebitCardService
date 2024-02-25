using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Queries;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetUserMeHandler : IRequestHandler<GetUserMeRequest, GetUserMeResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetUserMeHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetUserMeResponse> Handle(GetUserMeRequest request, CancellationToken cancellationToken)
    {
        if (request.Me != "me")
        {
            return new GetUserMeResponse
            {
                Error = new ErrorModel(ErrorType.UnsupportedMethod)
            };
        }

        var query = new GetUserMeQuery
        {
            Id = request.IdAuthentication
        };
        var user = await _queryExecutor.Execute(query);
        if (user == null)
        {
            return new GetUserMeResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedUser = _mapper.Map<User>(user);
        var response = new GetUserMeResponse { Data = mappedUser };
        return response;
    }
}
