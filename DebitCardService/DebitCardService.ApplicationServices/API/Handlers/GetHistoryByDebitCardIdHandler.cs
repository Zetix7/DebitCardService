using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Queries;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetHistoryByDebitCardIdHandler : IRequestHandler<GetHistoryByDebitCardIdRequest, GetHistoryByDebitCardIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetHistoryByDebitCardIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetHistoryByDebitCardIdResponse> Handle(GetHistoryByDebitCardIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetHistoryByDebitCardIdQuery
        {
            DebitCardId = request.DebitCardId,
        };
        var history = await _queryExecutor.Execute(query);
        var domainHistory = _mapper.Map<List<History>>(history);
        var response = new GetHistoryByDebitCardIdResponse
        {
            Data = domainHistory
        };
        return response;
    }
}
