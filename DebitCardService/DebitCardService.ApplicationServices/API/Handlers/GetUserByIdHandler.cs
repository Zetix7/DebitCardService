using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Queries;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetUserByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery
        {
            Id = request.UserId
        };
        var user = await _queryExecutor.Execute(query);
        var domainUser = _mapper.Map<User>(user);
        var response = new GetUserByIdResponse
        {
            Data = domainUser,
        };
        return response;
    }
}
