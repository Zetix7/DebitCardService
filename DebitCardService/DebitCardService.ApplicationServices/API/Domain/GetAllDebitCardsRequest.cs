using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetAllDebitCardsRequest : IRequest<GetAllDebitCardsResponse>
{
    public int UserId { get; set; }
}
