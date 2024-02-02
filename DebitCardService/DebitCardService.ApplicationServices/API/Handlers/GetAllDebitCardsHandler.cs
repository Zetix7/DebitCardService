using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetAllDebitCardsHandler : IRequestHandler<GetAllDebitCardsRequest, GetAllDebitCardsResponse>
{
    private readonly IRepository<DataAccess.Entities.DebitCard> _debitCardRepository;
    private readonly IMapper _mapper;

    public GetAllDebitCardsHandler(IRepository<DataAccess.Entities.DebitCard> debitCardRepository, IMapper mapper)
    {
        _debitCardRepository = debitCardRepository;
        _mapper = mapper;
    }

    public Task<GetAllDebitCardsResponse> Handle(GetAllDebitCardsRequest request, CancellationToken cancellationToken)
    {
        var debitCards = _debitCardRepository.GetAll();
        var mappedDebitCards = _mapper.Map<List<DebitCard>>(debitCards);

        var response = new GetAllDebitCardsResponse
        {
            Data = mappedDebitCards
        }
        ;
        return Task.FromResult(response);
    }
}
