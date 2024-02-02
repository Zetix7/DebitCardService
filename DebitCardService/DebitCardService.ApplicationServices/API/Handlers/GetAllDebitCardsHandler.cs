using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Queries;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetAllDebitCardsHandler : IRequestHandler<GetAllDebitCardsRequest, GetAllDebitCardsResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetAllDebitCardsHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetAllDebitCardsResponse> Handle(GetAllDebitCardsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAllDebitCardsQuery();
        var debitCards = await _queryExecutor.Execute(query);
        var mappedDebitCards = _mapper.Map<List<DebitCard>>(debitCards);

        var response = new GetAllDebitCardsResponse
        {
            Data = mappedDebitCards
        }
        ;
        return response;
    }
}
