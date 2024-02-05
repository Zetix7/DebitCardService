using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetHistoryByDebitCardIdRequest : IRequest<GetHistoryByDebitCardIdResponse>
{
    public int DebitCardId { get; set; }
}
