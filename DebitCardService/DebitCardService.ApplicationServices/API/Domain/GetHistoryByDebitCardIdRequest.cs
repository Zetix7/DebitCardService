using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetHistoryByDebitCardIdRequest : RequestBase, IRequest<GetHistoryByDebitCardIdResponse>
{
    public int DebitCardId { get; set; }
}
