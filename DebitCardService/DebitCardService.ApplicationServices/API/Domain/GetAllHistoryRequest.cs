using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetAllHistoryRequest : RequestBase, IRequest<GetAllHistoryResponse>
{
    public decimal Amount { get; set; }
}
