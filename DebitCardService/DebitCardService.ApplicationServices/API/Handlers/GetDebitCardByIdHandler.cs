using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Queries;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetDebitCardByIdHandler : IRequestHandler<GetDebitCardByIdRequest, GetDebitCardByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetDebitCardByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetDebitCardByIdResponse> Handle(GetDebitCardByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetDebitCardByIdQuery
        {
            Id = request.Id,
        };
        var debitCard = await _queryExecutor.Execute(query);
        var domainDebitCard = _mapper.Map<DebitCard>(debitCard);
        var response = new GetDebitCardByIdResponse
        {
            Data = domainDebitCard,
        };
        return response;
    }
}
