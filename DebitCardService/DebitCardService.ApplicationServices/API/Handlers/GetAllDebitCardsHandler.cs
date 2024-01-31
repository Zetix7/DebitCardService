using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetAllDebitCardsHandler : IRequestHandler<GetAllDebitCardsRequest, GetAllDebitCardsResponse>
{
    private readonly IRepository<DataAccess.Entities.DebitCard> _debitCardRepository;

    public GetAllDebitCardsHandler(IRepository<DataAccess.Entities.DebitCard> debitCardRepository)
    {
        _debitCardRepository = debitCardRepository;
    }

    public Task<GetAllDebitCardsResponse> Handle(GetAllDebitCardsRequest request, CancellationToken cancellationToken)
    {
        var debitCards = _debitCardRepository.GetAll();

        return Task.FromResult(new GetAllDebitCardsResponse
        {
            Data = debitCards.Select(x => new DebitCard
            {
                Id = x.Id,
                AccountNumber = x.AccountNumber,
                Amount = x.Amount,
                CardNumber = x.CardNumber,
                ExpirityDate = x.ExpirityDate,
                CardHolder = x.CardHolder,
                IsActive = x.IsActive
            }).ToList()
        }); ;
    }
}
