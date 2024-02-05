using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Queries;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetAllHistoryHandler : IRequestHandler<GetAllHistoryRequest, GetAllHistoryResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetAllHistoryHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetAllHistoryResponse> Handle(GetAllHistoryRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAllHistoryQuery()
        {
            Amount = request.Amount,
        };
        var history = await _queryExecutor.Execute(query);
        var mappedHistory = _mapper.Map<List<History>>(history);

        var response = new GetAllHistoryResponse
        {
            Data = mappedHistory,
        };

        return response;
    }
}
