using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetAllDebitCardsRequest : RequestBase, IRequest<GetAllDebitCardsResponse>
{
    public int UserId { get; set; }
}
